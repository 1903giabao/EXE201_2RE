using EXE201_2RE_API.Auth;
using EXE201_2RE_API.Constants;
using EXE201_2RE_API.Domain.Helpers;
using EXE201_2RE_API.Models;
using EXE201_2RE_API.Repository;
using EXE201_2RE_API.Request;
using EXE201_2RE_API.Response;
using EXE201_2RE_API.Setting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EXE201_2RE_API.Service
{
    public class IdentityService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UnitOfWork _unitOfWork;

        public IdentityService(IOptions<JwtSettings> jwtSettingsOptions)
        {
            _unitOfWork ??= new UnitOfWork();
            _jwtSettings = jwtSettingsOptions.Value;
        }

        public async Task<IServiceResult> Signup(SignupRequest req)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(req.Username))
                {
                    return new ServiceResult(500, "Incorrect format of Username");
                }

                string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

                if (!Regex.IsMatch(req.Email, emailPattern))
                {
                    return new ServiceResult(500, "Incorrect format of Email");
                }

                string phonePattern = @"^(\+\d{1,2}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";

                if (!Regex.IsMatch(req.PhoneNumber, phonePattern))
                {
                    return new ServiceResult(500, "Incorrect format of Phone number");
                }

                var user = _unitOfWork.UserRepository.GetAll().Where(u => u.Email == req.Email).FirstOrDefault();
                if (user is not null)
                {
                    return new ServiceResult(500, "Email already exists");
                }

                var newAccount = new TblUser
                {
                    Username = req.Username,
                    Password = SecurityUtil.Hash(req.Password),
                    Email = req.Email,
                    Address = req.Address,
                    PhoneNumber = req.PhoneNumber,
                    IsShopOwner = req.IsShopOwner,
                    ShopAddress = req.ShopAddress,
                    RoleId = 1,
                    ShopDescription = req.ShopDescription,
                    ShopLogo = req.ShopLogo,
                    ShopName = req.ShopName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                _unitOfWork.UserRepository.PrepareCreate(newAccount);

                var res = await _unitOfWork.UserRepository.SaveAsync();

                if (res > 0)
                {
                    return new ServiceResult(202, "Sign up successfully");
                }

                return new ServiceResult(500, "Sign up fail");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public LoginResult Login(string email, string password)
        {
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.Email == email).FirstOrDefault();

            if (user is null)
            {
                return new LoginResult
                {
                    RoleName = null,
                    Authenticated = false,
                    Token = null,
                };
            }

            var hash = SecurityUtil.Hash(password);
            if (!user.Password.Equals(hash))
            {
                return new LoginResult
                {
                    RoleName = null,
                    Authenticated = false,
                    Token = null,
                };
            }

            return new LoginResult
            {
                RoleName = user.Role.Name,
                Authenticated = true,
                Token = CreateJwtToken(user),
            };
        }

        private SecurityToken CreateJwtToken(TblUser user)
        {
            var utcNow = DateTime.UtcNow;
            var authClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Username),
                new(ClaimTypes.Role, user.Role.Name),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(authClaims),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Expires = utcNow.Add(TimeSpan.FromHours(1)),
            };

            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
