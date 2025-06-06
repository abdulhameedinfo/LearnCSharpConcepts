using System.Drawing;
using BenchmarkDotNet.Running;
using LearnDotNetConsole.Databases.EntityFrameworkCore;
using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification;
using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Factories;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsWPF;
using Microsoft;
using Newtonsoft.Json;
using UnitOfWork;

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
            // Composition.CompleteRobot();

            // Decorator design pattern
            // MorningCofee.TakeCoffee();
            // NotificationSender.Send();

            //Compare ExceptBy and their alternatives
            // var summaryOfArrayBenchMark = BenchmarkRunner.Run<ExceptByAndAlternatives>();
            // dotnet run --project LearnDotNetConsole.csproj -c Release

            //Dependency inverstion  principle
            // new DIP_Principle_To_Send_Notifications();

            // System.Console.WriteLine(HOF.devide(6,2));
            // var swapHOF = HOF.devide.SwapHOF();
            // System.Console.WriteLine(swapHOF(2,6)); // Both should return same result as the later one is swapping the arguments

            // ZipIEnumerable();

            // new AllAlgorithms();
            // New lock type in C# 13
            // new NewLockType();

            // new ChainResponsibility().Start();
            // new ChainOfResponsibilities.ChainOfResponsibility();

            //Unit of work pattern
            // new UnitOfWorkExample().Start();
            
            // Call factory service which will call factory method to send notification. 
            var service = new NotificationServiceFactory(new EmailNotificationFactoryCreator());
            service.Send();
            service = new NotificationServiceFactory(new SmsNotificationFactoryCreator());
            service.Send();
        }
    }
}
