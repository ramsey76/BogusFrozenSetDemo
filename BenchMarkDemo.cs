using System.Text;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace benchmark;

[MemoryDiagnoser]
public class BenchMarkDemo
{
    private int NumberOfItem = 10000;

    [Benchmark]
    public string ConCatStringUsingStringBuilder()
    {
        var sb = new StringBuilder();
        for(int i = 0; i < NumberOfItem; i++)
        {
            sb.AppendLine($"Hello World {i}");
        }
        return sb.ToString();
    }

    [Benchmark]
    public string ConCatStringUsingListOfStrings()
    {
        var list = new List<String>();
        for(int i = 0; i < NumberOfItem; i++)
        {
            list.Add($"Hello World {i}");
        }
#pragma warning disable CS8603 // Possible null reference return.
        return list.ToString();
#pragma warning restore CS8603 // Possible null reference return.
    }
}
