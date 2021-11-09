using CacheDemo.Models;

namespace CacheDemo.Repositories
{
    public interface IPlanogramRepository
    {
        Planogram Get(int id);
    }
}