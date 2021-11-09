using CacheDemo.Models;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace CacheDemo.Repositories
{
    public class PlanogramRepository : IPlanogramRepository
    {
        private readonly ILogger<PlanogramRepository> logger;

        public PlanogramRepository(
            ILogger<PlanogramRepository> logger)
        {
            this.logger = logger;

            logger.LogInformation("PlanogramRepository: Started");
        }

        public Planogram Get(int id)
        {
            logger.LogInformation($"PlanogramRepository: Getting planogram id: {id}");
            Thread.Sleep(1000);

            return new Planogram()
            {
                PlanogramId = id
            };
        }
    }
}
