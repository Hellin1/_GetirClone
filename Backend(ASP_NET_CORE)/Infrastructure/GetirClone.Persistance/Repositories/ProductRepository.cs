using GetirClone.Application.Consts;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using GetirClone.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace GetirClone.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GetirCloneContext _context;
        private readonly ICacheService _cacheService;

        public ProductRepository(GetirCloneContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }


        public async Task<List<Product>> SearchProductsAsync(string searchStr, CancellationToken cancellationToken)
        {
            var result = await _context.Products.
                Where(p => p.Title.Contains(searchStr) || p.Description.Contains(searchStr) || p.SKU.Contains(searchStr)).
                ToListAsync(cancellationToken);

            return result;
        }

        public async Task<List<Product>> GetProductsWithCategories(CancellationToken cancellationToken)
        {
            var products = await _context.Products.
                Include(p => p.Category).
                ToListAsync(cancellationToken);

            return products;
        }

        public async Task<Product?> GetProductWithCategory(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.
                Include(p => p.Category).
                FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            return product;
        }
        public async Task<Object> GetProductsByCategory(int categoryId, CancellationToken cancellationToken)
        {
            var categoriesWithProducts = _cacheService.GetList<Category>(CacheConstants.ProductsWithCategories);
            if (categoriesWithProducts == null || categoriesWithProducts.Count == 0)
            {
                categoriesWithProducts = await _context.Categories.Where(p => p.ParentCategoryId == null).
                                                                   Include(p => p.SubCategories).
                                                                   ThenInclude(sc => sc.Products).
                                                                   ToListAsync(cancellationToken);
                _cacheService.SetList<Category>(CacheConstants.ProductsWithCategories, categoriesWithProducts);
            }


            var categoryDictionary = new Dictionary<string, Category>();

            foreach (var category in categoriesWithProducts)
            {
                categoryDictionary.Add(category.Name, category);
            }

            return categoryDictionary;
        }
    }
}