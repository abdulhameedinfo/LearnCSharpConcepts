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
        new Delegates();
    }
}