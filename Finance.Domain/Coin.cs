using System.Text.Json.Serialization;

namespace Finance.Domain
{
    public class Coin
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("buy")]
        public double Buy { get; set; }

        [JsonPropertyName("sell")]
        public object Sell { get; set; }

        [JsonPropertyName("variation")]
        public double Variation { get; set; }
    }
}
