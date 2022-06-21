using Application.Contracts.Domain.DTOs;
using MediatR;

namespace Application.Features.Commands
{
    public class GetPriceCommand : IRequest<PackageResponse>
    {
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
    }
}