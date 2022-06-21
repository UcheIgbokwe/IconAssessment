using Domain.Users;

namespace Application.Contracts.Infrastructure.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        int? ValidateToken(string token);
    }
}