using System.Text.Json.Serialization;

namespace Finance.Domain
{
    public class Logo
    {
        public string IdLogo { get; set; }
        [JsonPropertyName("small")]
        public string Small { get; set; }

        [JsonPropertyName("big")]
        public string Big { get; set; }
    }
}
