namespace CacheDemo
{
    public interface ICacheManager
    {
        void Add(object value, string key);
        void Remove(string key);

        T Get<T>(string key);
        bool TryGet(string key, out object _obj);
    }
}
