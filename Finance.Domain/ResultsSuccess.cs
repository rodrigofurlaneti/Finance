using System.Text.Json.Serialization;

namespace Finance.Domain
{
    public class ResultsSuccess
    {
        [JsonPropertyName("currencies")]
        public Currencies Currencies { get; set; }

        [JsonPropertyName("stocks")]
        public Stocks Stocks { get; set; }

        [JsonPropertyName("available_sources")]
        public List<string> Available_sources { get; set; }

        [JsonPropertyName("taxes")]
        public List<object> Taxes { get; set; }

        public ResultsSuccess()
        {
            
        }
    }
}
