using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ExceptByAndAlternatives
{
    static IEnumerable<dynamic> list1 = Enumerable.Range(1, 1000000).Select(x => new { Key = x }).ToList<dynamic>();
    static IEnumerable<dynamic> list2 = Enumerable.Range(500000, 100000).Select(x => new { Key = x }).ToList<dynamic>();
    public void Benchmark()
    {
        ExceptBy();

        WhereWithAny();

        GroupJoin();

        HashSet();

        ToLookup();
    }

    [Benchmark]
    public void ExceptBy()
    {
        var result = list1.ExceptBy(list2, selector => selector.Key);
        foreach (var item in result)
            System.Console.WriteLine(item);
    }

    [Benchmark]
    public void ToLookup()
    {
        // ToLookup
        var excludeLookup = list2.ToLookup(y => y.Key);
        var result = list1.Where(x => !excludeLookup.Contains(x.Key)).ToList();
        foreach (var item in result)
            System.Console.WriteLine(item);
    }

    [Benchmark]
    public void HashSet()
    {
        // HashSet
        var keysToExclude = new HashSet<dynamic>(list2.Select(y => y.Key));
        var result = list1.Where(x => !keysToExclude.Contains(x.Key)).ToList();

        foreach (var item in result)
            System.Console.WriteLine(item);
    }

    [Benchmark]
    public void GroupJoin()
    {
        // GroupJoin
        var result = list1
            .GroupJoin(list2, x => x.Key, y => y.Key, (x, ys) => new { x, ys })
            .Where(g => !g.ys.Any())
            .Select(g => g.x)
            .ToList();

        foreach (var item in result)
            System.Console.WriteLine(item);
    }

    [Benchmark]
    public void WhereWithAny()
    {
        //"Where with Any"
        var result = list1.Where(x => !list2.Any(y => x.Key == y.Key)).ToList();
        foreach (var item in result)
            System.Console.WriteLine(item);
    }
}
