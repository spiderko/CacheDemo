using Microsoft.Extensions.Caching.Memory;

namespace CacheDemo
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache cache;

        public CacheManager(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public void Add(object value, string key)
        {
            cache.Set(key, value);
        }

        public T Get<T>(string key)
        {
            return cache.Get<T>(key);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public bool TryGet(string key, out object _obj)
        {
            return cache.TryGetValue(key, out _obj);
        }
    }
}
