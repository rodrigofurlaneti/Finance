using Finance.Domain;

namespace Finance.Service.Implementation
{
    public class GrahamMethodologyService
    {
        public IEnumerable<Graham> GetGrahamMethodology(IEnumerable<Active> model, IEnumerable<Graham> result)
        {
            foreach (var item in model)
            {
                if (item.Price != 0)
                {
                    if (item.Financials.Dividends.Yield_12m != 0)
                    {
                        result.ToList().Add(new Graham
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

            result = result.Select(p => new Graham
            {
                Kind = p.Kind,
                Small = p.Small,
                Symbol = p.Symbol,
                Name = p.Name,
                CompanyName = p.CompanyName,
                Sector = p.Sector,
                Price = p.Price,
                Yield_12m = p.Yield_12m,
                AnnualGrowthRate = 0.95m,
                ReturnRate = 13.75m,
                Result = p.Yield_12m * (8.5m + (2 * 0.95m)) / 13.75m
            }).OrderByDescending(p => p.Result).ToList();

            return result;
        }

        public async Task<IEnumerable<Graham>> GetGrahamMethodologyAsync(IEnumerable<Active> model, IEnumerable<Graham> result)
        {
            return await Task.Run(() =>
            {
                foreach (var item in model)
                {
                    if (item.Price != 0)
                    {
                        if (item.Financials.Dividends.Yield_12m != 0)
                        {
                            result.ToList().Add(new Graham
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

                result = result.Select(p => new Graham
                {
                    Kind = p.Kind,
                    Small = p.Small,
                    Symbol = p.Symbol,
                    Name = p.Name,
                    CompanyName = p.CompanyName,
                    Sector = p.Sector,
                    Price = p.Price,
                    Yield_12m = p.Yield_12m,
                    AnnualGrowthRate = 0.95m,
                    ReturnRate = 13.75m,
                    Result = p.Yield_12m * (8.5m + (2 * 0.95m)) / 13.75m
                }).OrderByDescending(p => p.Result).ToList();

                return result;
            });
        }
    }
}
