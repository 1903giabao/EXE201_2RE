﻿using AutoMapper;
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

namespace EXE201_2RE_API.Service
{
    public class CartService
    {
        private readonly UnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

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

                var result = await _unitOfWork.CartRepository.CreateAsync(cart);

                var listCartDetail = new List<TblCartDetail>();

                if (result > 0)
                {
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

                        listCartDetail.Add(cartDetail);
                    }

                    var cartDetailRs = await _unitOfWork.CartDetailRepository.CreateRangeAsync(listCartDetail);

                    if (cartDetailRs < 1)
                    {
                        return new ServiceResult(500, "Error when checkout!");
                    }
                }

                if (result < 1)
                {
                    return new ServiceResult(500, "Error when checkout!");
                }

                if (req.paymentMethod.Equals("QRPAY"))
                {
                    var uniqueId = cart.cartId.ToString().Substring(0, 8);

                    var apiRequest = new QRCodeRequest
                    {
                        acqId = 970423,
                        accountNo = "0901379036",
                        accountName = "EXETWORE",
                        amount = req.price,
                        logo = "data:image/png;base64,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",
                        addInfo = "Thanh toán đơn hàng " + uniqueId + " tại 2RE Secondhand",
                        template = "compact2",
                        theme = "compact2"
                    };

                    var jsonRequest = JsonConvert.SerializeObject(apiRequest);
                    var client = new RestClient("https://api.vietqr.io/v2/generate");
                    var request = new RestRequest();

                    request.Method = Method.Post;
                    request.AddHeader("Accept", "application/json");

                    request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

                    var response = client.Execute(request, Method.Post);
                    var content = response.Content;
                    var dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);

                    //var image = QRCodeRequest.ConvertBase64ToIFormFile(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""), "QRCode.png");

                    return new ServiceResult(200, "Checkout success", dataResult.data.qrDataURL);
                }
                else if (req.paymentMethod.Equals("COD"))
                {
                    return new ServiceResult(200, "Checkout success");
                }

                return new ServiceResult(500, "Failed!");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
