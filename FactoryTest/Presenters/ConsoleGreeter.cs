using Microsoft.Extensions.Logging;
using CacheDemo.Readers;
using CacheDemo.Models;

namespace CacheDemo.Presenters
{
    public class ConsoleGreeter : IGreeter
    {
        private readonly IPlanogramReader planogramReader;
        private readonly ILocationReader locationReader;
        private readonly ILogger<ConsoleGreeter> logger;

        public ConsoleGreeter(
            IPlanogramReader planogramReader,
            ILocationReader locationReader,
            ILogger<ConsoleGreeter> logger)
        {
            this.planogramReader = planogramReader;
            this.locationReader = locationReader;
            this.logger = logger;
        }

        public void Greet()
        {
            Planogram planogram;
            Location location;

            logger.LogInformation("All reads should be loaded from repository");

            for (int i = 0; i < 10; i++)
            {
                planogram = planogramReader.Get(i.ToString());
                location = locationReader.Get(i.ToString());

                logger.LogInformation($"Loaded Planogram with Id: {planogram.PlanogramId}");
                logger.LogInformation($"Loaded Location with Id: {location.LocationId}");
            }

            logger.LogInformation("All reads should be loaded from cache");
            for (int i = 0; i < 10; i++)
            {
                planogram = planogramReader.Get(i.ToString());
                location = locationReader.Get(i.ToString());

                logger.LogInformation($"Loaded Planogram with Id: {planogram.PlanogramId}");
                logger.LogInformation($"Loaded Location with Id: {location.LocationId}");
            }

            logger.LogInformation("Finished");
        }
    }
}
