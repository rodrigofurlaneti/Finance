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
        //EvEbitda
        public decimal EvEbitda { get; set; } = 0.00m;
        //DY
        public decimal DividendYield { get; set; } = 0.00m;
        //PL = Share Price / Earnings per Share
        public decimal PriceProfit { get; set; } = 0.00m;
        //P VP = Price (of the share) / Equity Value (of  the share)
        public decimal PriceOverAssetValue { get; set; } = 0.00m;
        //ROE = (Net Profit / Shareholders' Equity) x 100
        public decimal ReturnOnEquity { get; set; } = 0.00m;
        //DlEbitda
        public decimal DlEbitda { get; set; } = 0.00m;
        //CompoundAnnualGrowthRate
        public decimal CompoundAnnualGrowthRate { get; set; } = 0.00m;
        //EarningsPerShare
        public decimal EarningsPerShare { get; set; } = 0.00m;
        //EquityValuePerShare
        public decimal EquityValuePerShare { get; set; } = 0.00m;
        //FairValue
        public decimal FairValue { get; set; } = 0.00m;
        //UpdateAt
        public string UpdatedAt { get; set; } = string.Empty;
    }
}
