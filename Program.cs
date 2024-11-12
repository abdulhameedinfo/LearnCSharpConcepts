using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

public class Program
{


    public static void Main(string[] args)
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
        var nameInLowerCase = "ABDUL HAMEED".NameInLowerCase();
        System.Console.WriteLine("name in lower case: " +  nameInLowerCase);
        var meanOfTheValue = 100.Mean();
        System.Console.WriteLine("mean of the value: " + meanOfTheValue);


    }
}