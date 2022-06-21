using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Courier;
using MediatR;

namespace Application.Features.Commands
{
    public class GetPriceCommandHandler : IRequestHandler<GetPriceCommand, PackageResponse>
    {
        private readonly IPriceCalculator _priceCalculator;
        public GetPriceCommandHandler(IPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }
        public async Task<PackageResponse> Handle(GetPriceCommand request, CancellationToken cancellationToken)
        {
            return await _priceCalculator.GetPrice(request);
        }
    }
}