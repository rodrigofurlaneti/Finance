using System.Text.Json.Serialization;

namespace Finance.Web.Models
{
    public class Barsi
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
        [JsonPropertyName("change_percent")]
        public decimal Yield_12m { get; set; }
        [JsonPropertyName("result")]
        public decimal Result { get; set; }

    }
}
