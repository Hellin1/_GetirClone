using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class RemoveProductFromWishlistCommand : IRequest
    {
        public int WishlistId { get; set; }
        public int ProductId { get; set; }

        public RemoveProductFromWishlistCommand(int wishlistId, int productId)
        {
            WishlistId = wishlistId;
            ProductId = productId;
        }

    }
}
