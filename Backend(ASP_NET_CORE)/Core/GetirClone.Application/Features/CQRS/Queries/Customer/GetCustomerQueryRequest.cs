using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetCustomerQueryRequest : IRequest<CustomerListDto>
    {
        public int Id { get; set; }

        public GetCustomerQueryRequest(int id)
        {
            Id = id;
        }
    }
}
