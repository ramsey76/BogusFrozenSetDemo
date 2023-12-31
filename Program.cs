﻿using System.Text.Json;
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

            foreach (var deposant in deposanten)
            {
                //Console.WriteLine($"Deposant \t {deposant.FirstName} \t {deposant.LastName} \t {deposant.CountryCode} \t {deposant.Email}");
                Console.WriteLine($"Deposant \t {deposant.FirstName} \t {deposant.LastName} \t {deposant.CountryCode} \t {deposant.Bsn}");
            }


            foreach (var deposant in deposanten)
            {
                //Console.WriteLine($"Deposant \t {deposant.FirstName} \t {deposant.LastName} \t {deposant.CountryCode} \t {deposant.Email}");
                Console.WriteLine($"Deposant \t {deposant.Street} \t {deposant.Postcode} \t {deposant.City}");
            }
        //var summary = BenchmarkRunner.Run<BenchMarkDemo>();
        //var summary = BenchmarkRunner.Run<BenchMarkFrozenSets>();
        //        var summary = BenchmarkRunner.Run<BenchMarkFrozenSetsDic>();
    }
}
