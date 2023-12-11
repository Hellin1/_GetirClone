using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class ToggleIsPrimaryAddressCommandValidator : AbstractValidator<ToggleIsPrimaryAddressCommand>
    {
        private readonly IUow _uow;
        public ToggleIsPrimaryAddressCommandValidator(IUow uow)
        {
            _uow = uow;

            RuleFor(cmd => cmd.Id).NotEmpty();
            RuleFor(cmd => cmd.CustomerId).NotEmpty();
        }
    }
}