using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetWishlistsQueryRequest : IRequest<List<WishlistListDto>>
    {
        public Guid CustomerId { get; set; }

        public GetWishlistsQueryRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
