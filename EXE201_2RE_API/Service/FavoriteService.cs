using AutoMapper;
using EXE201_2RE_API.Constants;
using EXE201_2RE_API.Models;
using EXE201_2RE_API.Repository;
using EXE201_2RE_API.Response;

namespace EXE201_2RE_API.Service
{
    public class FavoriteService
    {
        private readonly UnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public FavoriteService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IServiceResult> GetFavoriteProductsByUserId (int userId)
        {
            try
            {
                var result = _mapper.Map<List<GetFavoriteProductsResponse>>(await _unitOfWork.FavoriteRepository.FindByConditionAsync(_ => _.UserId == userId));

                return new ServiceResult(200, "Favorite products by user", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> AddFavoriteProduct(int userId, int productId)
        {
            try
            {
                var checkExisted = _unitOfWork.FavoriteRepository.FindByCondition(_ => _.ProductId == productId && _.UserId == userId).FirstOrDefault();
                
                if (checkExisted != null)
                {
                    return new ServiceResult(500, "Favorite already existed");
                }

                var favorite = new TblFavorite 
                { 
                    UserId = userId, 
                    ProductId = productId 
                };

                var result = await _unitOfWork.FavoriteRepository.CreateAsync(favorite);
                if (result < 1)
                {
                    return new ServiceResult(500, "Error while creating object");
                }

                return new ServiceResult(200, "Create favorite");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
