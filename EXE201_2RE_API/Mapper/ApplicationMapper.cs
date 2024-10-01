using AutoMapper;
using EXE201_2RE_API.DTOs;
using EXE201_2RE_API.Models;
using EXE201_2RE_API.Response;

namespace EXE201_2RE_API.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UserModel, TblUser>().ReverseMap();
            CreateMap<ProductModel, TblProduct>().ReverseMap();
            CreateMap<GetFavoriteProductsResponse, TblFavorite>().ReverseMap();
        }
    }
}
