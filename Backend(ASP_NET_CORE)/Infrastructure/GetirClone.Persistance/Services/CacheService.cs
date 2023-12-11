using GetirClone.Application.Interfaces;
using GetirClone.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace GetirClone.Persistance.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly GetirCloneContext _context;

        public CacheService(IDistributedCache distributedCache, GetirCloneContext context)
        {
            _distributedCache = distributedCache;
            _context = context;
        }

        public T? Get<T>(string key)
        {
            var cachedData = _distributedCache.Get(key);
            return cachedData != null ? JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(cachedData), GetJsonSettings()) : default;
        }

        public List<T>? GetList<T>(string key)
        {
            var cachedData = _distributedCache.Get(key);

            return cachedData != null ? JsonConvert.DeserializeObject<List<T>>(Encoding.UTF8.GetString(cachedData), GetJsonSettings()) : default;
        }

        public async Task<List<T>?> GetOrSetList<T>(string key, TimeSpan? absoluteExpiration = null) where T : class, new()
        {
            var cachedData = _distributedCache.Get(key);


            if (cachedData != null)
            {
                return JsonConvert.DeserializeObject<List<T>>(Encoding.UTF8.GetString(cachedData), GetJsonSettings());
            }

            var dataFromDb = await _context.Set<T>().ToListAsync();

            SetList<T>(key, dataFromDb, absoluteExpiration);

            return dataFromDb;
        }

        public void Set<T>(string key, T value, TimeSpan? absoluteExpiration = null)
        {
            var serializedValue = JsonConvert.SerializeObject(value, GetJsonSettings());

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpiration
            };

            if (cacheOptions.AbsoluteExpirationRelativeToNow.HasValue)
            {
                cacheOptions.AbsoluteExpiration = DateTime.UtcNow.Add(cacheOptions.AbsoluteExpirationRelativeToNow.Value);
                cacheOptions.AbsoluteExpirationRelativeToNow = null;
            }

            _distributedCache.Set(key, Encoding.UTF8.GetBytes(serializedValue), cacheOptions);
        }

        public void SetList<T>(string key, List<T> values, TimeSpan? absoluteExpiration = null)
        {
            var serializedValues = JsonConvert.SerializeObject(values, GetJsonSettings());

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpiration
            };

            if (cacheOptions.AbsoluteExpirationRelativeToNow.HasValue)
            {
                cacheOptions.AbsoluteExpiration = DateTime.UtcNow.Add(cacheOptions.AbsoluteExpirationRelativeToNow.Value);
                cacheOptions.AbsoluteExpirationRelativeToNow = null;
            }

            _distributedCache.Set(key, Encoding.UTF8.GetBytes(serializedValues), cacheOptions);
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        private static JsonSerializerSettings GetJsonSettings()
        {
            return new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }
    }
}
