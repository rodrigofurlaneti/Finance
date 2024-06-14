using System.Text.Json.Serialization;

namespace Finance.Models
{
    public class Active
    {
        [JsonPropertyName("IdActive")]
        public int IdActive { get; set; }
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("company_name")]
        public string Company_name { get; set; }

        [JsonPropertyName("document")]
        public string Document { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("sector")]
        public string Sector { get; set; }

        [JsonPropertyName("financials")]
        public Financials Financials { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("market_time")]
        public MarketTime Market_time { get; set; }

        [JsonPropertyName("logo")]
        public Logo Logo { get; set; }

        [JsonPropertyName("market_cap")]
        public double Market_cap { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("change_percent")]
        public double Change_percent { get; set; }

        [JsonPropertyName("change_price")]
        public double Change_price { get; set; }

        [JsonPropertyName("updated_at")]
        public string Updated_at { get; set; }
    }
}
