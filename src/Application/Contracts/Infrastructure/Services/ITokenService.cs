using Domain.Users;

namespace Application.Contracts.Infrastructure.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string ValidateToken(string token);
    }
}