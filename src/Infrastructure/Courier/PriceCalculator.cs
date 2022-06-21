using Application.Behaviours;
using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Courier;
using Application.Contracts.Infrastructure.Repository;
using Application.Features.Commands;
using Domain.LogisticsDetails;
using Domain.LogisticsDetails.Dimensions;
using Domain.LogisticsDetails.WeightInKg;
using Domain.Users;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Courier
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly ICargo4You _cargo4You;
        private readonly IMaltaShip _maltaShip;
        private readonly IShipFaster _shipFaster;
        private readonly ILogger<PriceCalculator> _logger;
        private readonly ILogisticsRepository _logisticsRepository;
        public PriceCalculator(ICargo4You cargo4You, IMaltaShip maltaShip, IShipFaster shipFaster, ILogger<PriceCalculator> logger, ILogisticsRepository logisticsRepository)
        {
            _logisticsRepository = logisticsRepository;
            _logger = logger;
            _shipFaster = shipFaster;
            _maltaShip = maltaShip;
            _cargo4You = cargo4You;
        }

        public Dictionary<int, decimal> GetMaxPrice(double weight, Dimension dimension)
        {
            /*Get the maximum price for each courier*/
            Dictionary<int, decimal> myPriceList = new()
            {
                { 0, Math.Max(_cargo4You.ParcelLessThanEqual2000Cm(dimension), _cargo4You.ParcelLessThanEqual20Kg(weight)) },
                { 1, Math.Max(_shipFaster.ParcelGreaterThan10kgLessThanEqual30Kg(weight), _shipFaster.ParcelLessThanEqual1700Cm(dimension)) },
                { 2, Math.Max(_maltaShip.ParcelGreaterThanEqual10kg(weight), _maltaShip.ParcelGreaterThanEqual5000Cm(dimension)) }
            };

            return myPriceList;
        }

        public Task<PackageResponse> GetPrice(GetPriceCommand request)
        {
            try
            {
                var dimensionValue = new Dimension(request.Width, request.Height, request.Depth);
                var dict = GetMaxPrice(request.Weight, dimensionValue);
                /*Get the best price amongst each courier*/
                var finalPrice = dict.Values.Min();

                PackageResponse result = new()
                {
                    DimensionValue = dimensionValue.CalculatedDimension,
                    Weight = request.Weight,
                    Price = finalPrice
                };
                /*Save to database*/
                _logisticsRepository.CreateRecord(ConfigureData(result, request));
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetPrice: {ex.Message}", ex.Message);
                throw new InvalidResponseException(ex.Message, ex);
            }
        }

        private static LogisticsDetail ConfigureData(PackageResponse response, GetPriceCommand request)
        {
            return new LogisticsDetail()
            {
                WeightKg = new WeightKg(response.Weight),
                Dimension = new Dimension(request.Width, request.Height, request.Depth),
                User = new User()
            };
        }
    }
}