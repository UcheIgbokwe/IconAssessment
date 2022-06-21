using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure.Courier;
using Infrastructure.Courier;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //Register Logger used within the UoW for each Repo.
            // var serviceProvider = services.BuildServiceProvider();
            // var logger = serviceProvider.GetService<ILogger<GarageRepository>>();
            // services.AddSingleton(typeof(ILogger), logger);

            services.AddScoped<ICargo4You, Cargo4You>();
            services.AddScoped<IMaltaShip, MaltaShip>();
            services.AddScoped<IShipFaster, ShipFaster>();
            services.AddScoped<IPriceCalculator, PriceCalculator>();

            return services;
        }
    }
}