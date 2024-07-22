using System.Text.Json.Serialization;

namespace Finance.Domain
{
    public class Lynch
    {
        [JsonPropertyName("king")]
        public string Kind { get; set; }
        [JsonPropertyName("small")]
        public string Small { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }
        [JsonPropertyName("sector")]
        public string Sector { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("earningsPerShare")]
        public decimal EarningsPerShare { get; set; }
        [JsonPropertyName("growthRate")]
        public decimal GrowthRate { get; set; }
        [JsonPropertyName("pERatio")]
        public decimal PERatio { get; set; }
        [JsonPropertyName("pEGRatio")]
        public decimal PEGRatio { get; set; }
    }
}
