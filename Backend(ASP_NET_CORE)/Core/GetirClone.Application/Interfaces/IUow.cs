namespace GetirClone.Application.Interfaces
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();

        void SaveChanges();

        Task SaveChangesAsync();

    }
}
