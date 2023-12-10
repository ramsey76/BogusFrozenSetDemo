using Benchmark.Models;

namespace benchmark;

public class CountryCodesGenerator
{
    public static List<CountryCode> Generate()
    {
        var fileName = "Data/all.json";
        var jsonAsString = File.ReadAllText(fileName);

        var countryCodes = JsonSerializer.Deserialize<List<CountryCode>>(jsonAsString)!;
        return countryCodes;
    }
}
