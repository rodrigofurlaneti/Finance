using System.Text.Json.Serialization;

namespace Finance.Models
{
    public class MarketTime
    {
        [JsonPropertyName("open")]
        public string OpenTime { get; set; }

        [JsonPropertyName("close")]
        public string CloseTime { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }
    }
}
