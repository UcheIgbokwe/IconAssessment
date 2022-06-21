
using Application.Contracts.Infrastructure.Services;
using Infrastructure.Services;

namespace API.Config.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserServices>();

            return services;
        }
    }
}