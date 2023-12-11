using GetirClone.Application.Features.CQRS.Commands.PaymentCard;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class ChangeActiveCardCommandHandler : IRequestHandler<ChangeActiveCardCommand>
    {
        private readonly IPaymentCardRepository _paymentCardRepository;

        public ChangeActiveCardCommandHandler(IPaymentCardRepository paymentCardRepository)
        {
            _paymentCardRepository = paymentCardRepository;
        }

        public async Task<Unit> Handle(ChangeActiveCardCommand request, CancellationToken cancellationToken)
        {
            await _paymentCardRepository.ChangePaymentCard(request.CardId, request.CustomerId, cancellationToken);
            return Unit.Value;
        }
    }
}
