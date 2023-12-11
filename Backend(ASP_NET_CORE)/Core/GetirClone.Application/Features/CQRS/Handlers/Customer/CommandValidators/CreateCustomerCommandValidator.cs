using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly IUow _uow;
        public CreateCustomerCommandValidator(IUow uow)
        {
            _uow = uow;

            RuleFor(cmd => cmd.Name).NotEmpty().MaximumLength(100);
            RuleFor(cmd => cmd.Email).NotEmpty().MaximumLength(300);
            RuleFor(cmd => cmd.PhoneNumber).Cascade(CascadeMode.Stop).NotEmpty().MaximumLength(50).Matches("^\\+?\\d{8,15}$").Must(NotBeInDataBase);
        }

        private bool NotBeInDataBase(string phoneNumber)
        {
            return !_uow.GetRepository<Customer>().GetQuery().Any(c => c.PhoneNumber == phoneNumber);
        }

    }
}
