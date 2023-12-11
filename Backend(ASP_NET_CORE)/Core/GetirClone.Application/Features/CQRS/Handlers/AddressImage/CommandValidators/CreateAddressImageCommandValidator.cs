using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateAddressImageCommandValidator : AbstractValidator<CreateAddressImageCommand>
    {
        public CreateAddressImageCommandValidator()
        {
            RuleFor(cmd => cmd.ImageUrl).NotEmpty();
            RuleFor(cmd => cmd.Title).NotEmpty();
        }
    }
}
