using GetirClone.Application.Interfaces;
using GetirClone.Persistance.Context;
using GetirClone.Persistance.Repositories;

namespace GetirClone.Persistance.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly GetirCloneContext _context;

        public Uow(GetirCloneContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
