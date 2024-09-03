namespace Finance.Domain
{
    public class Indicators
    {
        //Id
        public int Id { get; set; }
        //TICKER
        public string Symbol { get; set; } = string.Empty;
        //PRICE
        public decimal Price { get; set; } = 0.00m;
        //DY
        public decimal DividendYield { get; set; } = 0.00m;
        //PL = Share Price / Earnings per Share
        public decimal PriceProfit { get; set; } = 0.00m;
        //P VP = Price (of the share) / Equity Value (of  the share)
        public decimal PriceOverAssetValue { get; set; } = 0.00m;
        //ROE = (Net Profit / Shareholders' Equity) x 100
        public decimal ReturnOnEquity { get; set; } = 0.00m;
        //UpdateAt
        public string UpdatedAt { get; set; } = string.Empty;
    }
}
