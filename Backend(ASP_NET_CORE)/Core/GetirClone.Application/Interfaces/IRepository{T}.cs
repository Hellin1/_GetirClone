using System.Linq.Expressions;

namespace GetirClone.Application.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken);
        Task<T?> GetByFilterAsyncNoTracking(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<T?> CreateAsync(T entity);
        void Update(T entity);
        void UpdatePartialRows(T entity, T unchanged);
        void UpdatePartials(T entity);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
        IQueryable<T> GetQuery();
    }
}
