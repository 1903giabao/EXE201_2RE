﻿using AutoMapper;
using EXE201_2RE_API.Constants;
using EXE201_2RE_API.Exceptions;
using EXE201_2RE_API.DTOs;
using EXE201_2RE_API.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXE201_2RE_API.Response;
using Microsoft.EntityFrameworkCore;
using EXE201_2RE_API.Enums;
using EXE201_2RE_API.Request;
using EXE201_2RE_API.Domain.Helpers;
using EXE201_2RE_API.Helpers;

namespace EXE201_2RE_API.Service
{

    public class UserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public readonly IFirebaseService _firebaseService;

        public UserService(UnitOfWork unitOfWork, IMapper mapper, IFirebaseService firebaseService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _firebaseService = firebaseService;
        }
        public async Task<IServiceResult> GetAllRole()
        {
            try
            {
                var listRoles = _unitOfWork.RoleRepository.GetAll().Select(_ => new RoleModel
                {
                    roleid = (Guid)_.roleId,
                    roleName = _.name
                });
                return new ServiceResult(200, "Get all roles", listRoles);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);

            }
        }
        public async Task<IServiceResult> GetAllUser()
        {
            try
            {
                var listUser = _unitOfWork.UserRepository.GetAllIncluding(_ => _.role);
                var result = listUser.Select(_ => new UserModel
                {
                     userId = (Guid)_.userId,
                     userName = _.userName,
                     passWord = _.passWord,
                     email = _.email,
                     address = _.address,
                     phoneNumber = _.phoneNumber,
                     roleId = _.roleId,
                     roleName = _.role.name,
                     isShopOwner = _.isShopOwner,
                     shopName = _.shopName,
                     shopAddress = _.shopAddress,
                     shopDescription = _.shopDescription,
                     shopLogo = _.shopLogo,
                     createdAt = (DateTime)_.createdAt,
                     updatedAt = (DateTime)_.updatedAt
                 }).ToList();    
                return new ServiceResult(200, "Get user by user name", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<IServiceResult> GetAllUserByRoleId(Guid roleId)
        {
            try
            {
                var listUser = _unitOfWork.UserRepository.GetAllIncluding(_ => _.role).Where(_ => _.roleId == roleId);
                var result = listUser.Select(_ => new UserModel
                {
                    userId = (Guid)_.userId,
                    userName = _.userName,
                    passWord = _.passWord,
                    email = _.email,
                    address = _.address,
                    phoneNumber = _.phoneNumber,
                    roleId = _.roleId,
                    roleName = _.role.name,
                    isShopOwner = _.isShopOwner,
                    shopName = _.shopName,
                    shopAddress = _.shopAddress,
                    shopDescription = _.shopDescription,
                    shopLogo = _.shopLogo,
                    createdAt = (DateTime)_.createdAt,
                    updatedAt = (DateTime)_.updatedAt
                }).ToList();
                return new ServiceResult(200, "Get user by roleId", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> UpdateProfile(Guid userId, UpdateProfileRequest req)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

                if (user == null)
                {
                    return new ServiceResult(404, "User not found!");
                }

                user.passWord = SecurityUtil.Hash(req.passWord);
                user.phoneNumber = req.phoneNumber;
                user.address = req.address;

                if ((bool)user.isShopOwner)
                {
                    user.shopName = req.shopName;
                    user.shopDescription = req.shopDescription;
                    user.shopAddress = req.shopAddress;
                }
                if (req.shopLogo != null && req.shopLogo.Length > 0)
                {
                    if (!string.IsNullOrEmpty(user.shopLogo))
                    {
                        string url = $"{FirebasePathName.AVATAR}{user.userId}";
                        var deleteResult = await _firebaseService.DeleteFileFromFirebase(url);
                        if (!deleteResult.isSuccess)
                        {
                            return new ServiceResult(500, "Failed to upload one or more images", null);
                        }
                    }
                    var imagePath = $"{FirebasePathName.AVATAR}{user.userId}";
                    var imageUploadResult = await _firebaseService.UploadFileToFirebase(req.shopLogo, imagePath);

                    if (imageUploadResult.isSuccess)
                    {
                        user.shopLogo = (string)imageUploadResult.result;
                    }
                    else
                    {
                        return new ServiceResult(500, "Failed to upload one or more images", null);
                    }
                }
                var rs = await _unitOfWork.UserRepository.UpdateAsync(user);

                if (rs > 0)
                {
                    return new ServiceResult(200, "Update user profile!", user);
                }

                return new ServiceResult(500, "Update failed!");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> DashboardOfShop(Guid shopId)
        {
            try
            {
                var shop = await _unitOfWork.UserRepository
                                            .GetAllIncluding(_ => _.reviewsReceivedAsShop, _ => _.reviewsWritten)
                                            .Where(_ => _.isShopOwner == true && _.userId == shopId)
                                            .FirstOrDefaultAsync();

                if (shop == null)
                {                
                    return new ServiceResult(404, "Shop not found!");
                }

                var totalProducts = _unitOfWork.ProductRepository.GetAll().Where(p => p.shopOwnerId == shopId && p.status.Equals(SD.ProductStatus.AVAILABLE)).Count();

                var listCarts = await _unitOfWork.CartRepository.GetAllIncluding(cd => cd.tblCartDetails).ToListAsync();

                int totalCartCount = 0;

                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;

                var currentMonthRevenue = 0.0;

                var listMonthlyRevenue = new List<MonthlyRevenue>();


                foreach (var cart in listCarts)
                {
                    cart.tblCartDetails = await _unitOfWork.CartDetailRepository.GetAllIncluding(cd => cd.product).ToListAsync();

                    if (cart.tblCartDetails.Any(cd => cd.product != null && cd.product.shopOwnerId == shopId))
                    {
                        totalCartCount++;

                        if (cart.dateTime.HasValue && cart.dateTime.Value.Month == currentMonth && cart.dateTime.Value.Year == currentYear)
                        {
                            currentMonthRevenue += (double)cart.totalPrice;
                        }
                    }
                }

                for (int i = 1; i < 13; i++)
                {
                    var revenue = 0.0;
                    foreach (var cart in listCarts)
                    {
                        if (cart.tblCartDetails.Any(cd => cd.product != null && cd.product.shopOwnerId == shopId))
                        {
                            if (cart.dateTime.HasValue && cart.dateTime.Value.Month == i && cart.dateTime.Value.Year == currentYear)
                            {
                                revenue += (double)cart.totalPrice;
                            }
                        }
                    }

                    var monthlyRevenue = new MonthlyRevenue
                    {
                        month = i,
                        revenue = revenue,
                    };

                    listMonthlyRevenue.Add(monthlyRevenue);
                }

                var response = new DashboardOfShopResponse
                {
                    totalProducts = totalProducts,
                    totalOrders = totalCartCount,
                    totalRatings = shop.reviewsReceivedAsShop.Sum(_ => _.rating ?? 0),
                    monthlyRevenue = listMonthlyRevenue,
                    revenueThisMonth = currentMonthRevenue
                };

                return new ServiceResult(200, "Success", response);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        private MonthlyRevenue GetMonthlyRevenue(Guid shopId)
        {
            var currentMonth = DateTime.Now.Month;

            var revenue = _unitOfWork.CartRepository.GetAll()
                    .Where(cart => cart.userId == shopId &&
                                   cart.dateTime.HasValue &&
                                   cart.dateTime.Value.Month == currentMonth)
                    .Sum(cart => (double?)cart.totalPrice) ?? 0.0;

            return new MonthlyRevenue
            {
                month = DateTime.Now.Month,
                revenue = revenue
            };
        }

        public async Task<UserModel> GetUserInToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new BadRequestException("Authorization header is missing or invalid.");
            }
            // Decode the JWT token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Check if the token is expired
            if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                throw new BadRequestException("Token has expired.");
            }
            string userName = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            var user = _unitOfWork.UserRepository.GetAll().Where(x => x.email == userName).FirstOrDefault();
            if (user is null)
            {
                throw new BadRequestException("Cannot find User");
            }
            return _mapper.Map<UserModel>(user);
        }

        public async Task<IServiceResult> GetUserByEmail(string username)
        {
            try
            {
                var result = _mapper.Map<UserModel>(_unitOfWork.UserRepository.GetAllIncluding(u => u.role).Where(_ => _.email == username).FirstOrDefault());
                return new ServiceResult(200, "Get user by user name", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
