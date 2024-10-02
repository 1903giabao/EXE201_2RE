using AutoMapper;
using EXE201_2RE_API.Constants;
using EXE201_2RE_API.DTOs;
using EXE201_2RE_API.Enums;
using EXE201_2RE_API.Helpers;
using EXE201_2RE_API.Models;
using EXE201_2RE_API.Repository;

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
                var products = _mapper.Map<List<ProductModel>>(await _unitOfWork.ProductRepository.GetAllAsync());
                return new ServiceResult(200, "Get all products", products);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetProductById(Guid id)
        {
            try
            {
                var product = _mapper.Map<ProductModel>(await _unitOfWork.ProductRepository.GetByIdAsync(id));
                return new ServiceResult(200, "Get product by id", product);
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
                var newProduct = new TblProduct
                {
                    productId = Guid.NewGuid(),
                    categoryId = createProductModel.categoryId,
                    genderCategoryId = createProductModel.genderCategoryId,
                    shopOwnerId = createProductModel.shopOwnerId,
                    sizeId = createProductModel.sizeId,
                    description = createProductModel.description,
                    name = createProductModel.name,
                    price = createProductModel.price,
                    createdAt = DateTime.Now,
                    status = SD.GeneralStatus.ACTIVE,
                };

                if (createProductModel.imgUrl != null)
                {
                    var imagePath = FirebasePathName.PRODUCT + $"{newProduct.productId}";
                    var imageUploadResult = await _firebaseService.UploadFileToFirebase(createProductModel.imgUrl, imagePath);

                    if (!imageUploadResult.isSuccess)
                    {
                        return new ServiceResult(500, "Failed to upload image", null);
                    }

                    newProduct.imgUrl = (string)imageUploadResult.result;
                }
                else
                {
                    return new ServiceResult(400, "Product image is required", null);
                }

                var result = await _unitOfWork.ProductRepository.CreateAsync(newProduct);
                if (result > 0)
                {
                    return new ServiceResult(200, "Product created successfully", newProduct);
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
