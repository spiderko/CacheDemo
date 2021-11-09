using CacheDemo.Presenters;
using CacheDemo.Readers;
using CacheDemo.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace CacheDemo
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            GreetWithDependencyInjection(host.Services);
            Console.ReadKey();

            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services
                        .AddLogging()
                        .AddMemoryCache()

                        .AddTransient<IGreeter, ConsoleGreeter>()
                        .AddTransient<ILocationReader, LocationReader>()
                        .AddTransient<IPlanogramReader, PlanogramReader>()
                        .AddTransient<ILocationRepository, LocationRepository>()
                        .AddTransient<IPlanogramRepository, PlanogramRepository>()

                        .AddSingleton<ICacheManager, CacheManager>());
        } 

        public static void GreetWithDependencyInjection(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var greeter = provider.GetRequiredService<IGreeter>();

            greeter.Greet();
        }
    }

}
