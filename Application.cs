using System.Drawing;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsWPF;
using Microsoft;
using Newtonsoft.Json;

public partial class Program
{
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

            //Compare ExceptBy and their alternatives
            // var summaryOfArrayBenchMark = BenchmarkRunner.Run<ExceptByAndAlternatives>();
            // dotnet run --project LearnCSharpConcepts.csproj -c Release

            //Dependency inverstion  principle
            // new DIP_Principle_To_Send_Notifications();

            System.Console.WriteLine("App WITHOUT DI...");
            // System.Console.WriteLine(HOF.devide(6,2));
            // var swapHOF = HOF.devide.SwapHOF();
            // System.Console.WriteLine(swapHOF(2,6)); // Both should return same result as the later one is swapping the arguments

            // ZipIEnumerable();

            new AllAlgorithms();
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
}
