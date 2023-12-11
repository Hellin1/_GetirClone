using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using GetirClone.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace GetirClone.Persistance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IUow _uow;
        private readonly GetirCloneContext _context;

        public CategoryRepository(IUow uow, GetirCloneContext context)
        {
            _uow = uow;
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.
                AsNoTracking().
                Where(c => c.ParentCategoryId == 0 || c.ParentCategoryId == null).
                Include(c => c.SubCategories).
                ToListAsync(cancellationToken);

            return categories;
        }
    }
}
