using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Services;
using Domain.Users;

namespace Infrastructure.Services
{
    public class UserServices : IUserService
    {
        private readonly ITokenService _tokenService;
        public UserServices(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            User user = new();
            AuthenticateResponse response = new()
            {
                id_token = _tokenService.GenerateToken(user)
            };

            return response;
        }

        public User GetById(string Id)
        {
            return new User();
        }
    }
}