using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetAddressQueryRequest : IRequest<AddressListDto>
    {
        public int Id { get; set; }

        public GetAddressQueryRequest(int id)
        {
            Id = id;
        }
    }
}
