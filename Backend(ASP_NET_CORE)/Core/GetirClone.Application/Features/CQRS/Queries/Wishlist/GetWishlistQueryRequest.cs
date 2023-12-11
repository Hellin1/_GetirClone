using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetWishlistQueryRequest : IRequest<WishlistListDto>
    {
        public GetWishlistQueryRequest(int id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }

        public int Id { get; set; }

        public Guid CustomerId { get; set; }


    }
}
