using System.Text.Json.Serialization;

namespace Finance.Models
{
    public class Dividends
    {
        public int IdDividends { get; set; }
        [JsonPropertyName("yield_12m")]
        public double Yield_12m { get; set; }

        [JsonPropertyName("yield_12m_sum")]
        public double Yield_12m_sum { get; set; }
    }
}
