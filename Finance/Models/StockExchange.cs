using System.Text.Json.Serialization;

namespace Finance.Models
{
    public class StockExchange
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("points")]
        public double Points { get; set; }

        [JsonPropertyName("variation")]
        public double Variation { get; set; }
    }
}
