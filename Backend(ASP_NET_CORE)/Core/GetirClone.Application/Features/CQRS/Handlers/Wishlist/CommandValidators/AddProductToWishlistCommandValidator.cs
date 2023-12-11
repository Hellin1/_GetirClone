using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class AddProductToWishlistCommandValidator : AbstractValidator<AddProductToWishlistCommand>
    {
        public AddProductToWishlistCommandValidator()
        {
            RuleFor(cmd => cmd.WishlistId).NotEmpty();
            RuleFor(cmd => cmd.CustomerId).NotEmpty();
            RuleFor(cmd => cmd.ProductId).NotEmpty();

        }
    }
}
