using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class AddProductToWishlistCommand : IRequest
    {
        public int WishlistId { get; set; }
        public Guid CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
