using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Finance.Domain
{
    public class Currencies
    {
            public string source { get; set; }
            public Coin USD { get; set; }
            public Coin EUR { get; set; }
            public Coin GBP { get; set; }
            public Coin ARS { get; set; }
            public Coin CAD { get; set; }
            public Coin AUD { get; set; }
            public Coin JPY { get; set; }
            public Coin CNY { get; set; }
            public Coin BTC { get; set; }
    }
}
