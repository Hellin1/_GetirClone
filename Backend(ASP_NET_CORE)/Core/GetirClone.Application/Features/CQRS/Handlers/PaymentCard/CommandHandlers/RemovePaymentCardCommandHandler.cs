using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RemovePaymentCardCommandHandler : IRequestHandler<RemovePaymentCardCommand>
    {
        private readonly IUow _uow;

        public RemovePaymentCardCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(RemovePaymentCardCommand request, CancellationToken cancellationToken)
        {
            var paymentCard = await _uow.GetRepository<PaymentCard>().GetByFilterAsync(pc => pc.Id == request.Id, cancellationToken);
            if (paymentCard != null)
            {
                if (paymentCard.IsPrimary)
                {
                    var randomCart = await _uow.GetRepository<PaymentCard>().GetByFilterAsync(pc => pc.CustomerId == request.CustomerId && pc.Id != request.Id, cancellationToken);
                    if (randomCart != null)
                    {
                        randomCart.IsPrimary = true;
                    }
                }

                paymentCard.IsPassive = true;
                paymentCard.IsPrimary = false;
                await _uow.SaveChangesAsync();
            }

            return Unit.Value;
        }

    }
}
