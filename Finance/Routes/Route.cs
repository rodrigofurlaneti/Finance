namespace Finance.Routes
{
    public class Route
    {
        public string RouteName { get; set; }   
        public string RouteValue { get; set; }
        public string Key { get; set; } = "6c0850e0";

        public Route()
        {
            
        }

        public Route GetMainIndices()
        {
            return new Route()
            {
                RouteName = "MainIndices",
                RouteValue = "https://api.hgbrasil.com/finance"
            };
        }

        public Route GetIbovespaShares()
        {
            return new Route()
            {
                RouteName = "IbovespaShares",
                RouteValue = "https://api.hgbrasil.com/finance/stock_price?key=" + Key + "&symbol="
            };
        }
    }
}
