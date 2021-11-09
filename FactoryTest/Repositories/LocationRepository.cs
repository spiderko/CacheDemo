using CacheDemo.Models;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace CacheDemo.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ILogger<LocationRepository> logger;

        public LocationRepository(
            ILogger<LocationRepository> logger)
        {
            this.logger = logger;

            logger.LogInformation("LocationRepository: Started");
        }

        public Location Get(int id)
        {
            logger.LogInformation($"LocationRepository: Getting location id: {id}");
            Thread.Sleep(1000);

            return new Location()
            {
                LocationId = id
            };
        }
    }
}
