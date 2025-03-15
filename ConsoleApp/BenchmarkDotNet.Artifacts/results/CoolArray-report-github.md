```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5011/22H2/2022Update)
Intel Core i5-6300U CPU 2.40GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.304
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method      | Mean     | Error     | StdDev    | Allocated |
|------------ |---------:|----------:|----------:|----------:|
| ClassArray  | 4.360 ms | 0.2229 ms | 0.6538 ms |      67 B |
| InlineArray | 4.790 ms | 0.2969 ms | 0.8325 ms |         - |
