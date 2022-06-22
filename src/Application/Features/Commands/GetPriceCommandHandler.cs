using Application.Contracts.Infrastructure.Courier;
using Application.Contracts.Infrastructure.Repository;
using MediatR;

namespace Application.Features.Commands
{
    public class GetPriceCommandHandler : IRequestHandler<GetPriceCommand, PackageResponse>
    {
        private readonly IPriceCalculator _priceCalculator;
        private readonly IUnitOfWork _unitOfWork;
        public GetPriceCommandHandler(IPriceCalculator priceCalculator, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _priceCalculator = priceCalculator;
        }
        public async Task<PackageResponse> Handle(GetPriceCommand request, CancellationToken cancellationToken)
        {
            var result = await _priceCalculator.GetPrice(request);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}