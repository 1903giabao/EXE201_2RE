using AutoMapper;
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

namespace EXE201_2RE_API.Service
{
    public class UserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _unitOfWork ??= new UnitOfWork();
            _mapper = mapper;
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
                var result = _mapper.Map<UserModel>(_unitOfWork.UserRepository.GetAll().Where(_ => _.email == username).FirstOrDefault());
                return new ServiceResult(200, "Get user by user name", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
