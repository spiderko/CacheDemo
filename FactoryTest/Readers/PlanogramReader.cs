using CacheDemo.Models;
using CacheDemo.Repositories;
using Microsoft.Extensions.Logging;

namespace CacheDemo.Readers
{
    public class PlanogramReader : IPlanogramReader
    {
        private readonly ICacheManager cache;
        private readonly IPlanogramRepository repository;
        private readonly ILogger<PlanogramReader> logger;
        private const string entityName = "Planogram";
        private string className = $"{entityName}Reader";

        public PlanogramReader(
            ICacheManager cache,
            IPlanogramRepository repository,
            ILogger<PlanogramReader> logger)
        {
            this.cache = cache;
            this.repository = repository;
            this.logger = logger;
        }

        public Planogram Get(string id)
        {
            var inCache = cache.TryGet($"{entityName}_{id}", out object obj);
            Planogram result;

            if (inCache)
            {
                logger.LogInformation($"{className}: {entityName} id:{id} Found in cache");
                result = (Planogram)obj;
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
