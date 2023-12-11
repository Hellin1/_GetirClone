using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreatePaymentCardCommandValidator : AbstractValidator<CreatePaymentCardCommand>
    {
        private readonly IUow _uow;
        public CreatePaymentCardCommandValidator(IUow uow)
        {
            _uow = uow;

            RuleFor(cmd => cmd.CardNickName).NotEmpty().MaximumLength(1000);
            RuleFor(cmd => cmd.CardNumber).Cascade(CascadeMode.Stop).NotEmpty().CreditCard().Must(NotBeInDataBase);
            RuleFor(cmd => cmd.CustomerId).NotEmpty();
            RuleFor(cmd => cmd.ExpiryDate).NotEmpty().MaximumLength(10);
            //RuleFor(x => x.CVV).NotEmpty().Matches("^\\d{3,4}$").MaximumLength(10);

            RuleFor(cmd => cmd.PaymentMethodId).NotEmpty();
        }

        private bool NotBeInDataBase(string cardNumber)
        {
            var isExist = _uow.GetRepository<PaymentCard>().GetQuery().Any(pc => pc.CardNumber == cardNumber && pc.IsPassive == false);
            return !isExist;
        }
    }
}
