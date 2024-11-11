
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class CoolArray
{
    public void CreateCoolArray()
    {
        ClassArray();
        InlineArray();
    }

    [Benchmark]
    public void ClassArray()
    {
        // Old .Net Array.

        var oldArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        foreach (var item in oldArray)
        {
            System.Console.WriteLine(item);
        }
    }

    [Benchmark]
    public void InlineArray()
    {
        // new .Net 8 (C# 12)
        var coolArray = new CoolArray<int>();
        coolArray[0] = 1;
        coolArray[1] = 2;
        coolArray[2] = 3;
        coolArray[3] = 4;
        coolArray[4] = 5;
        foreach (var item in coolArray)
        {
            System.Console.WriteLine(item);
        }
    }
}

[InlineArray(10)]
public struct CoolArray<T>
{
    private T firstName;
}