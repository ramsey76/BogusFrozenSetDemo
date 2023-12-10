using System.Text.Json;
using System.Text.Json.Nodes;
using Benchmark.Models;
using BenchmarkDotNet.Running;
using System.Collections.Frozen;

namespace benchmark;

class Program
{
    static void Main(string[] args)
    {
        //Show Faker
        var countryCodes = CountryCodesGenerator.Generate();
        var faker = Faker.GetDeposantGenerator(countryCodes.Select(c => c.Alpha3).ToList());
        
        var deposanten = faker.Generate(10);

        
        
        //var summary = BenchmarkRunner.Run<BenchMarkDemo>();
        //var summary = BenchmarkRunner.Run<BenchMarkFrozenSetsDic>();
        //var summary = BenchmarkRunner.Run<BenchMarkFrozenSets>();
    }
}
