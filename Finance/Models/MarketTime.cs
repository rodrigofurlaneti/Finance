using System.Text.Json.Serialization;

namespace Finance.Models
{
    public class MarketTime
    {
        public int IdMarketTime { get; set; }
        [JsonPropertyName("open")]
        public string Open { get; set; }

        [JsonPropertyName("close")]
        public string Close { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }
    }
}
