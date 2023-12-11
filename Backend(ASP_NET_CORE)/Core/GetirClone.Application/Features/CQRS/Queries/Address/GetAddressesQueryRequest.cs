using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetAddressesQueryRequest : IRequest<List<AddressListDto>>
    {
        public Guid CustomerId { get; set; }

        public GetAddressesQueryRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
