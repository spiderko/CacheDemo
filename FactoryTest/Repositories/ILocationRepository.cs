using CacheDemo.Models;

namespace CacheDemo.Repositories
{
    public interface ILocationRepository
    {
        Location Get(int id);
    }
}