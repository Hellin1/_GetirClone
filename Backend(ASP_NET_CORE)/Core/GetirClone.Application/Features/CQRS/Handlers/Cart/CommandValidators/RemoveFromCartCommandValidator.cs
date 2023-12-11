using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RemoveFromCartCommandValidator : AbstractValidator<RemoveFromCartCommand>
    {
        public RemoveFromCartCommandValidator()
        {
            RuleFor(cmd => cmd.CustomerId).NotEmpty();
            RuleFor(cmd => cmd.ProductId).NotEmpty();
        }
    }
}
