using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class UpdateWishlistCommandValidator : AbstractValidator<UpdateWishlistCommand>
    {
        public UpdateWishlistCommandValidator()
        {
            RuleFor(cmd => cmd.Id).NotEmpty().GreaterThan(0);
            RuleFor(cmd => cmd.Name).MaximumLength(300);
            RuleFor(cmd => cmd.CustomerId).NotEmpty();
        }
    }
}
