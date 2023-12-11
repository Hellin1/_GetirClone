using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetOrdersQueryRequest : IRequest<List<OrderWithoutNavPropsListDto>>
    {
        public Guid CustomerId { get; set; }

        public GetOrdersQueryRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
