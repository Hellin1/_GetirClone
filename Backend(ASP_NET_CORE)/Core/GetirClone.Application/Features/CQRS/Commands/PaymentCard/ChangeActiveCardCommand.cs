using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands.PaymentCard
{
    public class ChangeActiveCardCommand : IRequest
    {
        public int CardId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
