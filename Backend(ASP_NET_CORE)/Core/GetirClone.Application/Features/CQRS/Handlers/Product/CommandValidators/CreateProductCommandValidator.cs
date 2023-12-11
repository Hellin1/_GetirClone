using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(cmd => cmd.Title).NotEmpty().MaximumLength(400);
            RuleFor(cmd => cmd.BasePrice).NotEmpty().GreaterThan(0);
            RuleFor(cmd => cmd.Description).NotNull().MaximumLength(2000);
            RuleFor(cmd => cmd.Stock).NotEmpty().GreaterThan(0);
            RuleFor(cmd => cmd.CategoryId).NotEmpty();
            RuleFor(cmd => cmd.BrandId).NotEmpty();
            RuleFor(cmd => cmd.ProductTypeId).NotEmpty();
        }
    }
}
