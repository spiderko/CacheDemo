namespace CacheDemo.Readers
{
    public interface ICacheReader<T>
    {
        T Get(string key);
    }
}
