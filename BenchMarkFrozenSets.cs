using BenchmarkDotNet.Attributes;
using Benchmark.Models;
using System.Text.Json;
using System.Collections.Frozen;
using System.Collections.ObjectModel;

namespace benchmark;

[MemoryDiagnoser]
public class BenchMarkFrozenSets
{
    private List<string> listOfCountryCodes = new List<string>();

    private List<Deposant> listOfDeposanten =  new List<Deposant>();

    private FrozenSet<String> frozenSetOfCountryCodes;
    private HashSet<String> hashSetOfCountryCodes;
    private ReadOnlyCollection<string> readonlyListOfCountryCodes;

    [GlobalSetup]
    public void GlobalSetup()
    {
        List<CountryCode> countryCodes = CountryCodesGenerator.Generate();
        listOfCountryCodes = countryCodes.Select(cc => cc.Alpha3).ToList();

        var faker = Faker.GetDeposantGenerator(listOfCountryCodes);
        listOfDeposanten = faker.Generate(1000000);

        frozenSetOfCountryCodes = listOfCountryCodes.ToFrozenSet();
        hashSetOfCountryCodes = listOfCountryCodes.ToHashSet();
        readonlyListOfCountryCodes = listOfCountryCodes.AsReadOnly();
    }

    [Benchmark]
    public void CheckCountryCodeAgainstFrozenSet()
    {
        foreach(var deposant in listOfDeposanten)
        {
            frozenSetOfCountryCodes.Contains(deposant.CountryCode);
        }
    }

    [Benchmark]
    public void CheckCountryCodeAgainstHashSet()
    {
        foreach(var deposant in listOfDeposanten)
        {
            hashSetOfCountryCodes.Contains(deposant.CountryCode);
        }

    }
    
    [Benchmark]
    public void CheckCountryCodeAgainstReadonlyList()
    {
        foreach(var deposant in listOfDeposanten)
        {
            readonlyListOfCountryCodes.Contains(deposant.CountryCode);
        }
    }

}
