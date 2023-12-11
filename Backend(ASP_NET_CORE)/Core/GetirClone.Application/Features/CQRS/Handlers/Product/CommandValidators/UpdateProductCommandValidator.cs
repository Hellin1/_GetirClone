using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(cmd => cmd.Id).NotEmpty();
            RuleFor(cmd => cmd.Price).GreaterThan(0);
            RuleFor(cmd => cmd.BasePrice).NotEmpty().GreaterThan(0);
            RuleFor(cmd => cmd.Description).MaximumLength(3000);
            RuleFor(cmd => cmd.Title).MaximumLength(400);
            RuleFor(cmd => cmd.Stock).GreaterThanOrEqualTo(0);
            RuleFor(cmd => cmd.BrandId).NotEmpty();
            RuleFor(cmd => cmd.ProductTypeId).NotEmpty();
        }
    }
}
