namespace GetirClone.Application.Interfaces
{
    public interface ICacheService
    {
        T? Get<T>(string key);
        List<T?> GetList<T>(string key);
        Task<List<T>?> GetOrSetList<T>(string key, TimeSpan? absoluteExpiration = null) where T : class, new();
        void Set<T>(string key, T value, TimeSpan? absoluteExpiration = null);
        void SetList<T>(string key, List<T> values, TimeSpan? absoluteExpiration = null);
        void Remove(string key);

    }
}
