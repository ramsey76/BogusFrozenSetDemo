using System.Text.Json.Serialization;

namespace Benchmark.Models;

public class CountryCode
{
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("alpha-2")]
        public required string Alpha2 { get; set; }

        [JsonPropertyName("alpha-3")]
        public required string Alpha3 { get; set; }

        [JsonPropertyName("country-code")]
        public required string CountryISOCode { get; set; }

        [JsonPropertyName("iso_3166-2")]
        public required string iso_31662 { get; set; }
        [JsonPropertyName("region")]
        public required string Region { get; set; }

        [JsonPropertyName("sub-region")]
        public required string SubRegion { get; set; }

        [JsonPropertyName("intermediate-region")]
        public required string IntermediateRegion { get; set; }

        [JsonPropertyName("region-code")]
        public required string RegionCode { get; set; }

        [JsonPropertyName("sub-region-code")]
        public required string SubRegionCode { get; set; }

        [JsonPropertyName("intermediate-region-code")]
        public required string IntermediateRegionCode { get; set; }
}
