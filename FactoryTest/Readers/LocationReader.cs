using CacheDemo.Models;
using CacheDemo.Repositories;
using Microsoft.Extensions.Logging;

namespace CacheDemo.Readers
{
    public class LocationReader : ILocationReader
    {
        private readonly ICacheManager cache;
        private readonly ILocationRepository repository;
        private readonly ILogger<LocationReader> logger;
        private const string entityName = "Location";
        private string className = $"{entityName}Reader";

        public LocationReader(
            ICacheManager cache,
            ILocationRepository repository,
            ILogger<LocationReader> logger)
        {
            this.cache = cache;
            this.repository = repository;
            this.logger = logger;
        }

        public Location Get(string id)
        {
            var inCache = cache.TryGet($"{entityName}_{id}", out object obj);
            Location result;

            if (inCache)
            {
                logger.LogInformation($"{className}: {entityName} id:{id} Found in cache");
                result = (Location)obj;
            } else
            {
                logger.LogInformation($"{className}: {entityName} id:{id} NOT found in cache, going to repository.");
                result = repository.Get(int.Parse(id));
                cache.Add(result, $"{entityName}_{id}");
            }

            return result;
        }
    }
}
