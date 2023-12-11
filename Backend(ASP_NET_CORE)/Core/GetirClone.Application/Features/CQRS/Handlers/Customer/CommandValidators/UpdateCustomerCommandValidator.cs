using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private readonly IUow _uow;
        public UpdateCustomerCommandValidator(IUow uow)
        {
            _uow = uow;

            RuleFor(cmd => cmd.Id).Cascade(CascadeMode.Stop).NotEmpty().MustAsync(BeOnDatabase);
            RuleFor(cmd => cmd.Name).MaximumLength(100);
            RuleFor(cmd => cmd.Email).EmailAddress().MaximumLength(300);
            RuleFor(cmd => cmd.PhoneNumber).Cascade(CascadeMode.Stop).NotEmpty().Matches("^\\+?\\d{8,15}$").MaximumLength(50).Must(NotBeInDataBase);
        }

        private async Task<bool> BeOnDatabase(int id, CancellationToken token)
        {
            var customer = await _uow.GetRepository<Customer>().GetByIdAsync(id, token);
            if (customer == null) return false;

            return true;
        }

        private bool NotBeInDataBase(string phoneNumber)
        {
            return !_uow.GetRepository<Customer>().GetQuery().Any(c => c.PhoneNumber == phoneNumber);
        }


    }
}
