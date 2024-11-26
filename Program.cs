using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public partial class Program
{


    public static void Main(string[] args)
    {
        var services = CreateServices();

        // Resolve and start the Application without DI services
        var app = services.GetRequiredService<Application>();
        app.Start();

        // Resolve and start the Application with DI services
        var applicationWithDIServices = services.GetRequiredService<ApplicationWithDIServices>();
        applicationWithDIServices.Start();
    }

    private static ServiceProvider CreateServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<Application>() // Register Application
            .AddTransient<ApplicationWithDIServices>() // Register ApplicationWithDIServices
            .AddTransient<IProductService>(provider =>
            {
                // Resolve dependencies for the decorator pattern
                var productService = provider.GetRequiredService<ProductService>(); // Concrete service
                var memoryCache = provider.GetRequiredService<IMemoryCache>(); // MemoryCache service
                var logger = provider.GetRequiredService<ILogger<LoggingProductService>>(); // Logger service

                // Wrap ProductService with decorators
                var cachedProductService = new CachedProductService(productService, memoryCache);
                return new LoggingProductService(cachedProductService, logger);
            })
            .AddTransient<ProductService>() // Register ProductService explicitly (though not directly used in DI)
            .AddMemoryCache() // Add memory caching
            .AddLogging(configure => configure.AddConsole()) // Add logging
            .BuildServiceProvider();

        return serviceProvider;
    }
}