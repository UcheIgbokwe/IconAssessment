using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Helpers
{
    public static class JwtTokenManager
    {
        public static (object,object) GenerateJwtToken(ClaimsIdentity claims, IConfiguration _configuration)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = _configuration.GetSigningCredentials()
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var validToken = jwtTokenHandler.WriteToken(token);

            return (validToken, token.Id);
        }
        public static string GetAudience(this IConfiguration configuration)
        {
            var result = configuration.GetValue<string>("JwtSettings:Audience");
            return result;
        }
        public static string GetIssuer(this IConfiguration configuration)
        {
            var result = configuration.GetValue<string>("JwtSettings:Issuer");
            return result;
        }
        public static SigningCredentials GetSigningCredentials(this IConfiguration configuration)
        {
            return new SigningCredentials(configuration.GetSymmetricSigningKey(), SecurityAlgorithms.HmacSha256Signature);
        }
        public static SymmetricSecurityKey GetSymmetricSigningKey(this IConfiguration configuration)
        {
            var securityKey = configuration.GetIssuerSecurityKey();
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));
        }
        public static string GetIssuerSecurityKey(this IConfiguration configuration)
        {
            var result = configuration.GetValue<string>("JwtSettings:Secret");
            return result;
        }
    }
}