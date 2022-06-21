using Application.Contracts.Domain.DTOs;
using Application.Features.Commands;
using Domain.LogisticsDetails.Dimensions;

namespace Application.Contracts.Infrastructure.Courier
{
    public interface IPriceCalculator
    {
        Task<PackageResponse> GetPrice(GetPriceCommand request);
        Dictionary<int, decimal> GetMaxPrice(double weight, Dimension dimension);
    }
}