using GetirClone.Domain.Entities;

namespace GetirClone.Application.Interfaces
{
    public interface IWishlistRepository
    {
        Task<Wishlist> GetWishlistWithProducts(int id, Guid customerId, CancellationToken cancellationToken);

        Task<List<Wishlist>?> GetWishlistsWithProducts(Guid customerId, CancellationToken cancellationToken);

        Task<List<ProductWishlist>> GetProductWishlists(List<int> productIds, int wishlistId, CancellationToken cancellationToken);

        Task UpdateWishlists(int id, Wishlist wishlist, int productId, CancellationToken cancellationToken);

    }
}
