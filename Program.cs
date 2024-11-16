using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class Program
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

    public class Application
    {
        public void Start()
        {
            // Using generic function which accepts list of objects of both string and int to calculate the avereage. 
            // new GenericAvereageCalculate().CalculateAverage();

            // Compare classic array with new inline array
            // new CoolArray().CreateCoolArray();
            // var summaryOfArrayBenchMark = BenchmarkRunner.Run<CoolArray>();

            // Static Properties. 
            // new ClassWithStaticProperties();

            // Delegates
            // new Delegates();

            // Primary constructor allows parameters to be directly declared in a class or struct 
            // this helps to initilize the properties directly without the need of seperate constructor. 
            // System.Console.WriteLine(new PrimaryConstructor(1, "abdul hameed").Name);

            // Use extension methods
            // ExtensionMethods();

            // Composition design pattern: builds an object with flexible parts it needs.
            // CompositionPattern();

            // Decorator design pattern
            // DecoratorPattern();

            System.Console.WriteLine("This is application without DI services");
        }
    }

    public class ApplicationWithDIServices
    {
        private readonly IProductService _productService;

        public ApplicationWithDIServices(IProductService productService)
        {
            _productService = productService;
        }
        public void Start()
        {
            System.Console.WriteLine("This is application with DI services");

            // /Call decorator services
            var product = _productService.GetProductById(2);
            System.Console.WriteLine($"product is {product}");
        }
    }
    private static void ExtensionMethods()
    {
        var nameInLowerCase = "ABDUL HAMEED".NameInLowerCase();
        var meanOfTheValue = 100.Mean();
    }

    private static void CompositionPattern()
    {
        ISpeaker basicSpeaker = new BasicSpeaker();
        IMover basicMover = new BasicMover();
        var robot = new Robot(basicSpeaker, basicMover);
        System.Console.WriteLine(robot.CanSpeak());
        System.Console.WriteLine(robot.CanMove());
    }

    private static void DecoratorPattern()
    {
        // Start with a basic coffee
        ICoffee coffee = new BasicCoffee();
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

        // Add Sugar to the coffee
        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

        // Add Milk to the coffee
        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

        // Add Fruit Cake
        coffee = new FruitCakeDecorator(coffee);
        System.Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");
    }
}