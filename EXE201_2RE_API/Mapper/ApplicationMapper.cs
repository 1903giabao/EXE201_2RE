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
            CreateMap<TblProduct, GetListProductResponse>()
               .ForMember(dest => dest.shopOwner, opt => opt.MapFrom(src => src.shopOwner.shopName))
               .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.category.name))
               .ForMember(dest => dest.genderCategory, opt => opt.MapFrom(src => src.genderCategory.name))
               .ForMember(dest => dest.size, opt => opt.MapFrom(src => src.size.sizeName))
               .ForMember(dest => dest.imgUrl, opt => opt.MapFrom(src => src.tblProductImages.FirstOrDefault().imageUrl))
               .ReverseMap();
            CreateMap<TblProduct, GetProductDetailResponse>()
               .ForMember(dest => dest.shopOwner, opt => opt.MapFrom(src => src.shopOwner.shopName))
               .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.category.name))
               .ForMember(dest => dest.genderCategory, opt => opt.MapFrom(src => src.genderCategory.name))
               .ForMember(dest => dest.size, opt => opt.MapFrom(src => src.size.sizeName))
               .ForMember(dest => dest.mainImgUrl, opt => opt.MapFrom(src => src.tblProductImages.FirstOrDefault().imageUrl))
               .ForMember(dest => dest.listImgUrl, opt => opt.MapFrom(src => src.tblProductImages.Skip(1).Select(pi => pi.imageUrl).ToList()))
               .ReverseMap();
            CreateMap<FavoriteProductResponse, TblFavorite>().ReverseMap();
        }
    }
}
