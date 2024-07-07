﻿using System.Text.Json.Serialization;

namespace Finance.Domain
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
        public string CompanyName { get; set; }

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
        public MarketTime MarketTime { get; set; }

        [JsonPropertyName("logo")]
        public Logo Logo { get; set; }

        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("change_percent")]
        public decimal ChangePercent { get; set; }

        [JsonPropertyName("change_price")]
        public decimal ChangePrice { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
