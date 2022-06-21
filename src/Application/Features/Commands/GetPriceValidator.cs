using FluentValidation;

namespace Application.Features.Commands
{
    public class GetPriceValidator : AbstractValidator<GetPriceCommand>
    {
        public GetPriceValidator()
        {
            RuleFor(x => x.Depth)
                .Cascade(CascadeMode.Stop)
                .Must(x => Convert.ToInt32(x) > 0)
                .WithMessage("Please enter a valid depth.");
            RuleFor(x => x.Height)
                .Cascade(CascadeMode.Stop)
                .Must(x => Convert.ToInt32(x) > 0)
                .WithMessage("Please enter a valid height.");
            RuleFor(x => x.Width)
                .Cascade(CascadeMode.Stop)
                .Must(x => Convert.ToInt32(x) > 0)
                .WithMessage("Please enter a valid width.");
            RuleFor(x => x.Weight)
                .Cascade(CascadeMode.Stop)
                .Must(x => Convert.ToInt32(x) > 0)
                .WithMessage("Please enter a valid weight.");
        }
    }
}