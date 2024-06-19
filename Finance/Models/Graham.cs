using System.Text.Json.Serialization;

namespace Finance.Web.Models
{
    public class Graham
    {
        [JsonPropertyName("king")]
        public string Kind { get; set; }
        [JsonPropertyName("small")]
        public string Small { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }
        [JsonPropertyName("sector")]
        public string Sector { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("yield_12m")]
        public decimal Yield_12m { get; set; }
        [JsonPropertyName("annual_growth_rate")]
        public decimal AnnualGrowthRate { get; set; }
        [JsonPropertyName("return_rate")]
        public decimal ReturnRate { get; set; }
        [JsonPropertyName("result")]
        public decimal Result { get; set; }
    }
}
