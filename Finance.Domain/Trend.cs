using System.Text.Json.Serialization;

namespace Finance.Domain
{
    public class Trend
    {
        [JsonPropertyName("by")]
        public string By { get; set; }

        [JsonPropertyName("valid_key")]
        public bool Valid_key { get; set; }

        [JsonPropertyName("results")]
        public ResultsSuccess Results { get; set; }

        [JsonPropertyName("execution_time")]
        public double Execution_time { get; set; }

        [JsonPropertyName("from_cache")]
        public bool From_cache { get; set; }
    }
}
