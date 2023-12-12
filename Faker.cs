using Benchmark.Models;
using Bogus;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TraceReloggerLib;

namespace benchmark;

public static class Faker
{
    public static Faker<Deposant> GetDeposantGenerator(List<string> countryCodes)
    {
        return new Faker<Deposant>("it")
        .RuleFor(e => e.Id, _=> Guid.NewGuid())
        .RuleFor(e => e.FirstName, f => f.Name.FirstName())
        .RuleFor(e => e.LastName, f => f.Name.LastName())
        .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
        .RuleFor(e => e.CountryCode, f => f.PickRandom<string>(countryCodes))
        .RuleFor(e => e.Bsn, f => f.Random.Replace("#########"))
        .RuleFor(e => e.Street, f => f.Address.StreetAddress())
        .RuleFor(e => e.Postcode, f=> f.Address.ZipCode())
        .RuleFor(e => e.City, f=> f.Address.City())
        ;
    }
}
