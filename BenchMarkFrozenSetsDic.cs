using BenchmarkDotNet.Attributes;
using Benchmark.Models;
using System.Text.Json;
using System.Collections.Frozen;
using System.Collections.ObjectModel;
using Microsoft.Diagnostics.Runtime.DacInterface;
using System.Collections.Immutable;
using BenchmarkDotNet.Order;

namespace benchmark;

[MemoryDiagnoser, RankColumn, Orderer(SummaryOrderPolicy.FastestToSlowest)]
/*
Search 3 letter CountryCode in List and find Name
*/
public class BenchMarkFrozenSetsDic
{
    private Dictionary<string, string> listOfCountryCodesDics;

    private List<Deposant> listOfDeposanten =  new List<Deposant>();

    private FrozenDictionary<string,string> frozenSetOfCountryCodes;
    private Dictionary<string,string> dictionaryOfCountryCodes;
    private ImmutableDictionary<string,string> immutableDicOfCountryCodes;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var countryCodes = CountryCodesGenerator.Generate();
        listOfCountryCodesDics = countryCodes.ToDictionary(cc => cc.Alpha3, cc => cc.Name);

        var faker = Faker.GetDeposantGenerator(countryCodes.Select(c => c.Alpha3).ToList());
        listOfDeposanten = faker.Generate(1000000); // 1.000.000

        //Generate lists that are used in Benchmarking        
        dictionaryOfCountryCodes = listOfCountryCodesDics;
        immutableDicOfCountryCodes = listOfCountryCodesDics.ToImmutableDictionary();
        frozenSetOfCountryCodes = listOfCountryCodesDics.ToFrozenDictionary();
    }

    [Benchmark]
    public void CheckCountryCodeAgainstDictionary()
    {
        
        foreach (var deposant in listOfDeposanten)
        {
            dictionaryOfCountryCodes.TryGetValue(deposant.CountryCode, out string country);
        }

    }
    
    [Benchmark]
    public void CheckCountryCodeAgainstImmutableDictionary()
    {
        
        foreach (var deposant in listOfDeposanten)
        {
            immutableDicOfCountryCodes.TryGetValue(deposant.CountryCode, out string country);
        }
    }

    [Benchmark]
    public void CheckCountryCodeAgainstFrozenSet()
    {
        
        foreach (var deposant in listOfDeposanten)
        {
            frozenSetOfCountryCodes.TryGetValue(deposant.CountryCode, out string country);
        }
    }
}
