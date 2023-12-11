using GetirClone.Domain.Entities;

namespace GetirClone.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsWithCategories(CancellationToken cancellationToken);

        Task<Product?> GetProductWithCategory(int id, CancellationToken cancellationToken);

        Task<List<Product>> SearchProductsAsync(string searchStr, CancellationToken cancellationToken);

        Task<Object> GetProductsByCategory(int categoryId, CancellationToken cancellationToken);
    }
}
