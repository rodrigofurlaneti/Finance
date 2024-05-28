using System.Text.Json.Serialization;

namespace Finance.Models
{
    public class Financials
    {
        [JsonPropertyName("quota_count")]
        public int Quota_count { get; set; }

        [JsonPropertyName("dividends")]
        public Dividends Dividends { get; set; }
    }
}
