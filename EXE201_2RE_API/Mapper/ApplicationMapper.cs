﻿using AutoMapper;
using EXE201_2RE_API.Model;
using EXE201_2RE_API.Models;

namespace EXE201_2RE_API.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UserModel, TblUser>().ReverseMap();
            CreateMap<ProductModel, TblProduct>().ReverseMap();
        }
    }
}
