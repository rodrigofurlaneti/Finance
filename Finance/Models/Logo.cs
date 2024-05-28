using System.Text.Json.Serialization;

namespace Finance.Models
{
    public class Logo
    {
        [JsonPropertyName("small")]
        public string Small { get; set; }

        [JsonPropertyName("big")]
        public string Big { get; set; }
    }
}
