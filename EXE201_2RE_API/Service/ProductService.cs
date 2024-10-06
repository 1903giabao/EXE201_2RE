using AutoMapper;
using EXE201_2RE_API.Constants;
using EXE201_2RE_API.DTOs;
using EXE201_2RE_API.Enums;
using EXE201_2RE_API.Helpers;
using EXE201_2RE_API.Models;
using EXE201_2RE_API.Repository;
using EXE201_2RE_API.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;
using static EXE201_2RE_API.Response.GetListOrderFromShop;

namespace EXE201_2RE_API.Service
{
    public class ProductService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public readonly IFirebaseService _firebaseService;


        public ProductService(UnitOfWork unitOfWork, IMapper mapper, IFirebaseService firebaseService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _firebaseService = firebaseService;
        }

        public async Task<IServiceResult> GetAllProducts()
        {
            try
            {
                var productEntities = _unitOfWork.ProductRepository.GetAllIncluding(_ => _.shopOwner, _ => _.category, _ => _.genderCategory, _ => _.size, _ => _.tblProductImages);
                var products = _mapper.Map<List<GetListProductResponse>>(productEntities);
                return new ServiceResult(200, "Get all products", products);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<IServiceResult> GetProductByShopOwner(Guid shopId)
        {
            try
            {
                var productsOwnedByShopOwner = _unitOfWork.ProductRepository.GetAll()
                                                          .Where(_ => _.shopOwnerId == shopId)
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
                    var cart =  _unitOfWork.CartRepository.GetAllIncluding(_ => _.user).Where(_ => _.cartId == cartId).FirstOrDefault();
                    var totalProduct = _unitOfWork.CartDetailRepository.GetAll().Where(_ => _.cartId == cartId).Count();
                    var cartFromShop = new CartShopModel
                    {
                        id = (Guid)cartId,
                        nameUser = cart.fullName,
                        totalPrice = (decimal)cart.totalPrice,
                        totalQuantity = totalProduct,
                        status = cart.status

                    };
                    listCartFromShop.Add(cartFromShop);
                }

                return new ServiceResult(200, "Success", listCartFromShop);
            }
            catch(Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<IServiceResult> GetAllProductFromShop(Guid shopId)
        {
            try
            {
                var productsOwnedByShopOwner = _unitOfWork.ProductRepository.GetAllIncluding(_ => _.category, _ => _.genderCategory, _ => _.size, _ => _.tblProductImages)
                                                              .Where(_ => _.shopOwnerId == shopId)
                                                              .Select(_ => new GetAllProductFromShopResponse
                                                              {
                                                                  productId = _.productId,
                                                                  categoryId = (Guid)_.categoryId,
                                                                  categoryName = _.category.name,
                                                                  sizeId = (Guid)_.sizeId,
                                                                  sizeName = _.size.sizeName,
                                                                  name = _.name,
                                                                  price = (decimal)_.price,
                                                                  imageUrl = _.tblProductImages.Select(_ => _.imageUrl).FirstOrDefault(),
                                                                  brand = _.brand,
                                                                  description = _.description,
                                                              })
                                                              .ToList();
                return new ServiceResult(200, "Success", productsOwnedByShopOwner);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);

            }

        }
       /* public async Task<IServiceResult> GetAllShop()
        {
            try
            {
                
               *//* return new ServiceResult(200, "Success", productsOwnedByShopOwner);*//*
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);

            }

        }*/
        public async Task<IServiceResult> GetProductById(Guid id)
        {
            try
            {
                var productEntities = await _unitOfWork.ProductRepository.GetAllIncluding(_ => _.shopOwner, _ => _.category, _ => _.genderCategory, _ => _.size, _ => _.tblProductImages).Where(_ => _.productId == id).FirstOrDefaultAsync();
                var product = _mapper.Map<GetProductDetailResponse>(productEntities);
                return new ServiceResult(200, "Get product by id", product);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetListProductByListId(List<Guid> ids)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository
                    .GetAllIncluding(_ => _.shopOwner, _ => _.category, _ => _.genderCategory, _ => _.size, _ => _.tblProductImages)
                    .Where(p => ids.Contains(p.productId))
                    .ToListAsync();

                if (products == null || !products.Any())
                {
                    return new ServiceResult(404, "No products found for the provided IDs", null);
                }

                var productModel = _mapper.Map<List<GetListProductResponse>>(products);

                return new ServiceResult(200, "Get product by IDs", productModel);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetNewestProducts()
        {
            try
            {
                var products = _unitOfWork.ProductRepository
                    .GetAllIncluding(_ => _.shopOwner, _ => _.category, _ => _.genderCategory, _ => _.size, _ => _.tblProductImages)
                    .OrderByDescending(p => p.createdAt)
                    .Take(6)
                    .ToList();

                var productModel = _mapper.Map<List<GetListProductResponse>>(products);

                return new ServiceResult(200, "Get newest product", productModel);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetRelatedProducts(Guid id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                if (product == null)
                {
                    return new ServiceResult(404, "Product not found", null);
                }

                var products = _unitOfWork.ProductRepository
                    .GetAllIncluding(_ => _.shopOwner, _ => _.category, _ => _.genderCategory, _ => _.size, _ => _.tblProductImages)
                    .Where(p => p.categoryId == product.categoryId &&
                                 p.genderCategoryId == product.genderCategoryId &&
                                 p.productId != product.productId)
                    .ToList();

                var randomProducts = new List<TblProduct>();

                if (products.Count > 0)
                {
                    Random random = new Random();
                    int numberToTake = Math.Min(5, products.Count); 

                    var selectedIndices = new HashSet<int>();
                    while (selectedIndices.Count < numberToTake)
                    {
                        selectedIndices.Add(random.Next(products.Count));
                    }

                    foreach (var index in selectedIndices)
                    {
                        randomProducts.Add(products[index]);
                    }
                }

                var productModel = _mapper.Map<List<GetListProductResponse>>(randomProducts);

                return new ServiceResult(200, "Get related product", productModel);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> CreateProduct(CreateProductModel createProductModel)
        {
            try
            {
                var result = 0;
                var newProduct = new TblProduct();

                if (createProductModel.listImgUrl != null && createProductModel.listImgUrl.Any())
                {
                    newProduct = new TblProduct
                    {
                        productId = Guid.NewGuid(),
                        categoryId = createProductModel.categoryId,
                        genderCategoryId = createProductModel.genderCategoryId,
                        shopOwnerId = createProductModel.shopOwnerId,
                        sizeId = createProductModel.sizeId,
                        description = createProductModel.description,
                        name = createProductModel.name,
                        brand = createProductModel.brand,
                        condition = createProductModel.condition,
                        price = createProductModel.price,
                        createdAt = DateTime.Now,
                        status = SD.GeneralStatus.ACTIVE,
                    };

                    var imageUploadResults = new List<string>();
                    var productImages = new List<TblProductImage>();

                    foreach (var imgUrl in createProductModel.listImgUrl)
                    {
                        var imagePath = FirebasePathName.PRODUCT + $"{newProduct.productId}";
                        var imageUploadResult = await _firebaseService.UploadFileToFirebase(imgUrl, imagePath);

                        if (!imageUploadResult.isSuccess)
                        {
                            return new ServiceResult(500, "Failed to upload one or more images", null);
                        }

                        var uploadedImgUrl = (string)imageUploadResult.result;
                        imageUploadResults.Add(uploadedImgUrl);

                        var productImage = new TblProductImage
                        {
                            productImageId = Guid.NewGuid(),
                            productId = newProduct.productId,
                            imageUrl = uploadedImgUrl
                        };

                        productImages.Add(productImage);
                    }

                    result = await _unitOfWork.ProductRepository.CreateAsync(newProduct);
                    result += await _unitOfWork.ProductImageRepository.CreateRangeAsync(productImages);
                }
                else
                {
                    return new ServiceResult(400, "Product image is required", null);
                }

                if (result > 0)
                {
                    return new ServiceResult(200, "Product created successfully");
                }
                else
                {
                    return new ServiceResult(500, "Failed to create product", null);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
