using Application.Contracts.Domain.DTOs;
using Domain.Users;

namespace Application.Contracts.Infrastructure.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(string Id);
    }
}