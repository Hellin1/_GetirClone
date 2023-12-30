using GetirClone.Application.Interfaces;
using GetirClone.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GetirClone.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly GetirCloneContext _context;

        public Repository(GetirCloneContext context)
        {
            _context = context;
        }

        public async Task<T?> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByFilterAsyncNoTracking(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter, cancellationToken);
        }
        public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(new object?[] { id }, cancellationToken);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void UpdatePartialRows(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }

        public void UpdatePartials(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

    }
}
