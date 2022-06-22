using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Behaviours;
using Application.Contracts.Infrastructure.Services;
using Domain.Users;
using Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly TokenValidationParameters _tokenValidationParameters;
        public TokenService(IConfiguration configuration, TokenValidationParameters tokenValidationParameters)
        {
            _tokenValidationParameters = tokenValidationParameters;
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            // generate token that is valid for 1 hour
            var subjectClaim = new ClaimsIdentity(new []
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
            });
            var result = JwtTokenManager.GenerateJwtToken(subjectClaim, _configuration);

            return result.Item1.ToString();
        }
        public string ValidateToken(string token)
        {
            if (token == null)
            return null;

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                // Validation 1 - Validation JWT token format
                var tokenInVerification = jwtTokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);

                // Validation 2 - Validate encryption alg
                if(validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if(!result)
                    {
                        return null;
                    }
                }

                // Validation 3 - validate expiry date
                var utcExpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = UnixTimeStampToDateTime(utcExpiryDate);

                var userId = tokenInVerification.Claims.First(x => x.Type == "Id").Value;
                return userId;
            }
            catch (Exception ex)
            {
                throw new InvalidCredentialsException(ex.Message);
            }
        }
        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dateTimeVal = new DateTime(1970, 1,1,0,0,0,0, DateTimeKind.Utc);
            return dateTimeVal.AddSeconds(unixTimeStamp).ToUniversalTime();
        }
    }
}