using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using GetirClone.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace GetirClone.Persistance.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly GetirCloneContext _context;

        public WishlistRepository(GetirCloneContext context)
        {
            _context = context;
        }

        public async Task<List<Wishlist>?> GetWishlistsWithProducts(Guid customerId, CancellationToken cancellationToken)
        {
            var wishlists = await _context.Wishlists.Where(w => w.CustomerId == customerId).Include(w => w.ProductWishlists).ThenInclude(pw => pw.Product).ToListAsync(cancellationToken);

            return wishlists;
        }

        public async Task<Wishlist?> GetWishlistWithProducts(int wishlistId, Guid customerId, CancellationToken cancellationToken)
        {
            var wishlist = await _context.Wishlists.
                Include(p => p.ProductWishlists).
                ThenInclude(pw => pw.Product).
                FirstOrDefaultAsync(w => w.Id == wishlistId && w.CustomerId == customerId, cancellationToken);

            return wishlist;
        }

        public async Task<List<ProductWishlist>> GetProductWishlists(List<int> productIds, int wishlistId, CancellationToken cancellationToken)
        {
            var productWishlists = await _context.ProductWishlists.Where(w => productIds.Contains(w.ProductId) && w.WishlistId == wishlistId).ToListAsync(cancellationToken);

            return productWishlists;
        }

        public async Task UpdateWishlists(int id, Wishlist wishlist, int productId, CancellationToken cancellationToken)
        {
            var updatedEntity = await _context.Wishlists.Include(w => w.ProductWishlists).ThenInclude(pw => pw.Product).FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

            if (updatedEntity != null)
            {
                updatedEntity.ProductWishlists.Add(new ProductWishlist
                {
                    ProductId = productId,
                    WishlistId = id
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
