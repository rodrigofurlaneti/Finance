using System.Text.Json.Serialization;

namespace Finance.Models
{
    public class Stocks
    {
        [JsonPropertyName("IBOVESPA")]
        public StockExchange IBOVESPA { get; set; }

        [JsonPropertyName("IFIX")]
        public StockExchange IFIX { get; set; }

        [JsonPropertyName("NASDAQ")]
        public StockExchange NASDAQ { get; set; }

        [JsonPropertyName("DOWJONES")]
        public StockExchange DOWJONES { get; set; }

        [JsonPropertyName("CAC")]
        public StockExchange CAC { get; set; }

        [JsonPropertyName("NIKKEI")]
        public StockExchange NIKKEI { get; set; }
    }
}
