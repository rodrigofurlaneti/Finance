using Finance.Domain;
using Finance.Service.Interface;

namespace Finance.Service.Implementation
{
    public class CalculationOfTheBarsiService : ICalculationOfTheBarsiService
    {
        public IEnumerable<Barsi> GetCalculationOfTheBarsi(IEnumerable<Active> model)
        {
            List<Barsi> result = new List<Barsi>();

            foreach (var item in model)
            {
                if (item.Price != 0)
                {
                    if (item.Financials.Dividends.Yield_12m != 0)
                    {
                        result.Add(new Barsi
                        {
                            Kind = item.Kind,
                            Small = item.Logo.Small,
                            Symbol = item.Symbol,
                            Name = item.Name,
                            CompanyName = item.CompanyName,
                            Sector = item.Sector,
                            Price = item.Price,
                            Yield_12m = item.Financials.Dividends.Yield_12m_sum,
                        });
                    }
                }
            }

            result = result.Select(p => new Barsi
            {
                Kind = p.Kind,
                Small = p.Small,
                Symbol = p.Symbol,
                Name = p.Name,
                CompanyName = p.CompanyName,
                Sector = p.Sector,
                Price = p.Price,
                Yield_12m = p.Yield_12m,
                Result_Year = (p.Yield_12m / p.Price) * 100,
                Result_Month = ((p.Yield_12m / p.Price) * 100 / 12 )
            }).OrderByDescending(p => p.Result_Year).ToList();

            return result;
        }

        public async Task<IEnumerable<Barsi>> GetCalculationOfTheBarsiAsync(IEnumerable<Active> model)
        {
            return await Task.Run(() =>
            {
                var result = model
                    .Where(item => item.Price != 0 && item.Financials.Dividends.Yield_12m != 0)
                    .Select(item => new Barsi
                    {
                        Kind = item.Kind,
                        Small = item.Logo.Small,
                        Symbol = item.Symbol,
                        Name = item.Name,
                        CompanyName = item.CompanyName,
                        Sector = item.Sector,
                        Price = item.Price,
                        Yield_12m = item.Financials.Dividends.Yield_12m_sum,
                        Result_Year = (item.Financials.Dividends.Yield_12m_sum / item.Price) * 100,
                        Result_Month = ((item.Financials.Dividends.Yield_12m_sum / item.Price) * 100 / 12)
                    })
                    .OrderByDescending(p => p.Result_Year)
                    .ToList();

                return result.AsEnumerable();
            });
        }
    }
}
