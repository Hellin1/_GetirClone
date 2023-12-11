using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetPaymentCardQuery : IRequest<PaymentCardListDto>
    {
        public Guid CustomerId { get; set; }

        public GetPaymentCardQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
