namespace Finance.Domain
{
    public class Indicators
    {
        //Id
        public int Id { get; set; }
        //TICKER
        public string Symbol { get; set; } = string.Empty;
        //PRICE
        public string Price { get; set; } = string.Empty;
        //DY
        public string DividendYield { get; set; } = string.Empty;
        //PL = Share Price / Earnings per Share
        public string PriceProfit { get; set; } = string.Empty;
        //P VP = Price (of the share) / Equity Value (of  the share)
        public string PriceOverAssetValue { get; set; } = string.Empty;
        //ROE = (Net Profit / Shareholders' Equity) x 100
        public string ReturnOnEquity { get; set; } = string.Empty;
        //UpdateAt
        public string UpdatedAt { get; set; } = string.Empty;
    }
}
