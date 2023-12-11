using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateWishlistCommandValidator : AbstractValidator<CreateWishlistCommand>
    {
        public CreateWishlistCommandValidator()
        {
            RuleFor(cmd => cmd.CustomerId).NotEmpty();
            RuleFor(cmd => cmd.Name).NotEmpty().MaximumLength(300);
        }
    }
}
