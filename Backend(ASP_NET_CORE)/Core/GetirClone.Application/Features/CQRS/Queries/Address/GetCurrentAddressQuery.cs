using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries.Address
{
    public class GetCurrentAddressQuery : IRequest<AddressListDto>
    {
        public Guid CustomerId { get; set; }

        public GetCurrentAddressQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
