using GetirClone.Domain.Entities;

namespace GetirClone.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken);
    }
}
