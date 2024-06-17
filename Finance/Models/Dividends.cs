using System.Text.Json.Serialization;

namespace Finance.Models
{
    public class Dividends
    {
        //Percentual yield últimos 12 meses
        [JsonPropertyName("yield_12m")]
        public decimal Yield_12m { get; set; }

        //Soma últimos 12 meses em reais(R$)
        [JsonPropertyName("yield_12m_sum")]
        public decimal Yield_12m_sum { get; set; }
    }
}
