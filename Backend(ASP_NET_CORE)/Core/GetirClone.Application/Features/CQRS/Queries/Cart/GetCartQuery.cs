using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetCartQuery : IRequest<CartListDto>
    {
        public Guid CustomerId { get; set; }

        public GetCartQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
