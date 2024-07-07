using System.Text.Json.Serialization;

namespace Finance.Domain
{
    public class StockExchange
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("points")]
        public double Points { get; set; }

        [JsonPropertyName("variation")]
        public double Variation { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

    }
}
