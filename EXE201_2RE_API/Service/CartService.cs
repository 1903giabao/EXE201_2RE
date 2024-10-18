using AutoMapper;
using Net.payOS.Types;
using AutoMapper.Internal;
using EXE201_2RE_API.Constants;
using EXE201_2RE_API.Enums;
using EXE201_2RE_API.Helpers;
using EXE201_2RE_API.Models;
using EXE201_2RE_API.Repository;
using EXE201_2RE_API.Response;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;
using static EXE201_2RE_API.Response.GetListOrderFromShop;
using Net.payOS;

namespace EXE201_2RE_API.Service
{
    public class CartService
    {
        private readonly UnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private string cancelUrl = "https://localhost:7145/cart/return-url";
        private string returnUrl = "https://localhost:7145/cart/return-url";
        private string clientId = "9e463c91-db86-4e48-a738-2dd12f936bf0";
        private string apiKey = "221468d5-9a17-48f5-8521-a510bca81ccd";   
        private string checksumKey = "e12e2458eb05d7dbea1609ea69387ee6b217946df08917a49ff1c49c1d56fe1b";

        public CartService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IServiceResult> ChangeCartStatus(Guid cartId, string status)
        {
            try
            {
                var cart = await _unitOfWork.CartRepository.GetByIdAsync(cartId);

                cart.status = status;

                var result = await _unitOfWork.CartRepository.UpdateAsync(cart);

                return new ServiceResult(200, "Update cart status", cart);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetAllCart()
        {
            try
            {
                var productsOwnedByShopOwner = _unitOfWork.ProductRepository.GetAll()
                                                          .Select(_ => _.productId)
                                                          .ToList();

                var productInCartDetails = _unitOfWork.CartDetailRepository.GetAll()
                                                      .Where(_ => productsOwnedByShopOwner.Contains((Guid)_.productId))
                                                      .Select(_ => new { _.productId, _.cartId })
                                                      .ToList();

                var distinctCartIds = productInCartDetails
                                     .Select(_ => _.cartId)
                                     .Distinct()
                                     .ToList();
                var listCartFromShop = new List<CartShopModel>();
                foreach (var cartId in distinctCartIds)
                {
                    var cart = _unitOfWork.CartRepository.GetAllIncluding(_ => _.user).Where(_ => _.cartId == cartId).FirstOrDefault();
                    var totalProduct = _unitOfWork.CartDetailRepository.GetAll().Where(_ => _.cartId == cartId).Count();
                    listCartFromShop.Add(new CartShopModel
                    {
                        id = (Guid)cartId,
                        nameUser = cart.fullName,
                        totalPrice = (decimal)cart.totalPrice,
                        totalQuantity = totalProduct,
                        status = cart.status,
                        date = (DateTime)cart.dateTime,
                        paymentMethod = cart.paymentMethod
                    });
                }

                return new ServiceResult(200, "Success", listCartFromShop);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetCartsByUserId(Guid id)
        {
            try
            {
                var carts = _unitOfWork.CartRepository
                        .GetAllIncluding(
                            _ => _.user,
                            _ => _.tblCartDetails,
                            _ => _.tblOrderHistories
                        )
                        .Where(_ => _.userId == id).ToList();

                foreach (var cart in carts)
                {
                    foreach (var detail in cart.tblCartDetails)
                    {
                        detail.product = _unitOfWork.ProductRepository.GetAllIncluding(_ => _.size, _ => _.tblProductImages).Where(_ => _.productId == detail.productId).FirstOrDefault();
                    }
                }

                var cartResponses = new List<GetCartByUserIdResponse>();

                foreach (var cart in carts)
                {
                    var response = new GetCartByUserIdResponse
                    {
                        totalPrice = cart.totalPrice,
                        dateTime = cart.dateTime,
                        address = cart.address,
                        email = cart.email,
                        fullName = cart.fullName,
                        phone = cart.phone,
                        listProducts = new List<GetCartDetailResponse>(),
                        status = cart.status
                    };

                    foreach (var detail in cart.tblCartDetails)
                    {
                        var productResponse = new GetCartDetailResponse
                        {
                            productId = detail.productId,
                            price = detail.price,
                            name = detail.product?.name,
                            size = detail.product?.size?.sizeName,
                            imageUrl = detail.product?.tblProductImages.FirstOrDefault()?.imageUrl,
                        };

                        response.listProducts.Add(productResponse);
                    }

                    cartResponses.Add(response);
                }

                return new ServiceResult(200, "Carts retrieved successfully", cartResponses);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> Checkout(CheckoutRequest req)
        {
            try
            {
                //var user = _unitOfWork.UserRepository.FindByCondition(_ => _.email.ToLower().Equals(req.email.ToLower())).FirstOrDefault();
                var user = _unitOfWork.UserRepository.FindByCondition(_ => _.userId == req.userId).FirstOrDefault();

                if (user == null)
                {
                    return new ServiceResult(404, "Cannot find user");
                }

                Guid? firstShopId = null;

                foreach (var guid in req.products)
                {
                    var product = await _unitOfWork.ProductRepository.GetByIdAsync(guid);

                    if (product == null)
                    {
                        return new ServiceResult(404, "Cannot find product");
                    }

                    if (product.status.Equals(SD.ProductStatus.SOLDOUT))
                    {
                        return new ServiceResult(404, "Product is sold out!");
                    }

                    if (req.paymentMethod.Equals("QRPAY"))
                    {
                        if (firstShopId == null)
                        {
                            firstShopId = product.shopOwnerId;
                        }
                        else if (product.shopOwnerId != firstShopId)
                        {
                            return new ServiceResult(404, "Products belong to different shops!");
                        }
                    }

                }

                long uniqueId = 0;

                var cart = new TblCart
                {
                    cartId = Guid.NewGuid(),
                    userId = user.userId,
                    fullName = req.fullName,
                    email = req.email,
                    address = req.address,
                    phone = req.phone,
                    dateTime = DateTime.Now,
                    status = SD.CartStatus.PENDING,
                    totalPrice = req.price,
                    paymentMethod = req.paymentMethod,
                };

                Guid cartGuid = (Guid)cart.cartId;
                byte[] guidBytes = cartGuid.ToByteArray();
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hash = sha256.ComputeHash(guidBytes);

                    uniqueId = Math.Abs(BitConverter.ToInt64(hash, 0) / 1000000000);
                }

                cart.code = uniqueId.ToString();

                var result = await _unitOfWork.CartRepository.CreateAsync(cart);

                if (result > 0)
                {
                    PayOS payOS = new PayOS(clientId, apiKey, checksumKey);

                    List<ItemData> items = new List<ItemData>();

                    var listCartDetail = new List<TblCartDetail>();

                    var totalPrice = 0;

                    foreach (var item in req.products)
                    {
                        var product = await _unitOfWork.ProductRepository.GetByIdAsync(item); 

                        if (product == null)
                        {
                            return new ServiceResult(500, "Error when checkout!");

                        }

                        var cartDetail = new TblCartDetail
                        {
                            cartDetailId = Guid.NewGuid(),
                            cartId = cart.cartId,
                            productId = product.productId,
                            price = product.price,
                        };

                        totalPrice += (int)product.price;

                        listCartDetail.Add(cartDetail);

                        ItemData itemData = new ItemData(product.name, 1, (int)product.price);

                        items.Add(itemData);
                    }

                    var cartDetailRs = await _unitOfWork.CartDetailRepository.CreateRangeAsync(listCartDetail);

                    if (cartDetailRs < 1)
                    {
                        return new ServiceResult(500, "Error when checkout!");
                    }

                    if (req.paymentMethod.Equals("QRPAY"))
                    {
                        int billPrice = (totalPrice == 0) ? req.price : totalPrice;

                        PaymentData paymentData = new PaymentData(uniqueId, billPrice,
                            $"Thanh toán đơn {uniqueId}",
                            items, cancelUrl, returnUrl);

                        CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);

                        return new ServiceResult(200, "Checkout success", createPayment);
                    }
                    else if (req.paymentMethod.Equals("COD"))
                    {
                        return new ServiceResult(200, "Checkout success");
                    }
                }

                if (result < 1)
                {
                    return new ServiceResult(500, "Error when checkout!");
                }

                return new ServiceResult(500, "Failed!");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> UpdateCartStatus(long orderCode, string status)
        {
            try
            {
                var cart = _unitOfWork.CartRepository.GetAllIncluding(c => c.tblCartDetails).Where(c => c.code == orderCode.ToString()).FirstOrDefault();
                if (cart == null)
                {
                    return new ServiceResult(500, "Failed!");
                }

                int result = 0;

                if (status.Equals("PAID"))
                {
                    cart.status = SD.CartStatus.PAID;
                    result += await _unitOfWork.CartRepository.UpdateAsync(cart);
                }
                else if (status.Equals("CANCELLED"))
                {
                    var cartDetailsToRemove = new List<TblCartDetail>();

                    // Collect items to remove
                    foreach (var cartDetail in cart.tblCartDetails)
                    {
                        var cartRemove = await _unitOfWork.CartDetailRepository.GetByIdAsync(cartDetail.cartDetailId.Value);
                        cartDetailsToRemove.Add(cartRemove);
                    }

                    foreach (var cartDetail in cartDetailsToRemove)
                    {
                        await _unitOfWork.CartDetailRepository.RemoveAsync(cartDetail);
                    }

                    await _unitOfWork.CartRepository.RemoveAsync(cart);
                }

                if (result > 0)
                {
                    return new ServiceResult(200, "Paid success", cart);
                }
            
                return new ServiceResult(200, "Cancel success");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
