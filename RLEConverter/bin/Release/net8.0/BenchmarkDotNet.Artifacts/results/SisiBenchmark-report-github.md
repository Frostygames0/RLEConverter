```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3570/22H2/2022Update)
13th Gen Intel Core i5-13600K, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method  | Mean     | Error   | StdDev  |
|-------- |---------:|--------:|--------:|
| Where   | 129.6 μs | 0.52 μs | 0.48 μs |
| ForLoop | 110.3 μs | 0.16 μs | 0.13 μs |
