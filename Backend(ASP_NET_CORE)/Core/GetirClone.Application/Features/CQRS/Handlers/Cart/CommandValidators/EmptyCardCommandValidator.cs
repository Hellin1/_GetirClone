using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands.Cart;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class EmptyCardCommandValidator : AbstractValidator<EmptyCartCommand>
    {
        public EmptyCardCommandValidator()
        {
            RuleFor(cmd => cmd.CustomerId).NotEmpty();
        }
    }
}
