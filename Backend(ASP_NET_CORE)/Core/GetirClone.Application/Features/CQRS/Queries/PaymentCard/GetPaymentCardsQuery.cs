using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetPaymentCardsQuery : IRequest<List<PaymentCardListDto>>
    {
        public Guid CustomerId { get; set; }

        public GetPaymentCardsQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
