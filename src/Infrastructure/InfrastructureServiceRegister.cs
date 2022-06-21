using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure.Courier;
using Application.Contracts.Infrastructure.Repository;
using Infrastructure.Courier;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public static class InfrastructureServiceRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //Register Logger used within the UoW for each Repo.
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<LogisticsRepository>>();
            services.AddSingleton(typeof(ILogger), logger);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILogisticsRepository, LogisticsRepository>();

            services.AddScoped<ICargo4You, Cargo4You>();
            services.AddScoped<IMaltaShip, MaltaShip>();
            services.AddScoped<IShipFaster, ShipFaster>();
            services.AddScoped<IPriceCalculator, PriceCalculator>();

            return services;
        }
    }
}