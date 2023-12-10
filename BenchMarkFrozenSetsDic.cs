using BenchmarkDotNet.Attributes;
using Benchmark.Models;
using System.Text.Json;
using System.Collections.Frozen;
using System.Collections.ObjectModel;
using Microsoft.Diagnostics.Runtime.DacInterface;
using System.Collections.Immutable;

namespace benchmark;

[MemoryDiagnoser]
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
        var fileName = "Data/all.json";
        var jsonAsString = File.ReadAllText(fileName);

        var countryCodes = JsonSerializer.Deserialize<List<CountryCode>>(jsonAsString)!;
        listOfCountryCodesDics = countryCodes.ToDictionary(cc => cc.Alpha3, cc => cc.Name);

        var faker = Faker.GetDeposantGenerator(countryCodes.Select(c => c.Alpha3).ToList());
        listOfDeposanten = faker.Generate(1000000);

        frozenSetOfCountryCodes = listOfCountryCodesDics.ToFrozenDictionary();
        dictionaryOfCountryCodes = listOfCountryCodesDics;
        immutableDicOfCountryCodes = listOfCountryCodesDics.ToImmutableDictionary();
    }

    [Benchmark]
    public void CheckCountryCodeAgainstFrozenSet()
    {
        foreach(var deposant in listOfDeposanten)
        {
            frozenSetOfCountryCodes.TryGetValue(deposant.CountryCode, out string country);
        }
    }

    [Benchmark]
    public void CheckCountryCodeAgainstDictionary()
    {
        foreach(var deposant in listOfDeposanten)
        {
            dictionaryOfCountryCodes.TryGetValue(deposant.CountryCode, out string country);
        }

    }
    
    [Benchmark]
    public void CheckCountryCodeAgainstReadonlyList()
    {
        foreach(var deposant in listOfDeposanten)
        {
            immutableDicOfCountryCodes.TryGetValue(deposant.CountryCode, out string country);
        }
    }

}
