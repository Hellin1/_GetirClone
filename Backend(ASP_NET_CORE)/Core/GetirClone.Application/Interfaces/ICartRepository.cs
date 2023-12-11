using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Interfaces
{
    public interface ICartRepository
    {
        Task AddToCart(AddToCartCommand cmd, CancellationToken cancellationToken);
        Task RemoveFromCart(int productId, Guid customerId, CancellationToken cancellationToken);
        Task<Cart?> GetCartWithProducts(Guid customerId, CancellationToken cancellationToken);
        Task<Cart> GetCartIncludeAll(Guid customerId, CancellationToken cancellationToken);
        decimal CalculateCartTotal(Cart cart);
        Task ClearCart(Guid customerId, CancellationToken cancellationToken);
    }
}
