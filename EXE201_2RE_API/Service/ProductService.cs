using AutoMapper;
using EXE201_2RE_API.Constants;
using EXE201_2RE_API.Model;
using EXE201_2RE_API.Repository;

namespace EXE201_2RE_API.Service
{
    public class ProductService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public async Task<IServiceResult> GetProductById(int id)
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
    }
}
