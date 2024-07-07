using System.Text.Json.Serialization;

namespace Finance.Domain
{
    public class Financials
    {
        //Valor patrimonial (somente FIIs)
        [JsonPropertyName("equity")]
        public long? Equity { get; set; }

        //Valor patrimonial por cota (somente FIIs)
        [JsonPropertyName("equity_per_share")]
        public decimal? Equity_per_share { get; set; }

        //Preço sobre valor patrimonial
        [JsonPropertyName("price_to_book_ratio")]
        public decimal? Price_to_book_ratio { get; set; }

        //Cotas emitidas (FIIs / ordinária / preferencial)
        [JsonPropertyName("quota_count")]
        public long? Quota_count { get; set; }

        //
        [JsonPropertyName("dividends")]
        public Dividends Dividends { get; set; }
    }
}
