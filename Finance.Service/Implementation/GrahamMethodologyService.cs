using Finance.Domain;
using Finance.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Service.Implementation
{
    public class GrahamMethodologyService : IGrahamMethodologyService
    {
        public IEnumerable<Graham> GetGrahamMethodology(IEnumerable<Active> model)
        {
            List<Graham> result = new List<Graham>();

            foreach (var item in model)
            {
                if (item.Price != 0 && item.Financials.Dividends.Yield_12m != 0)
                {
                    var novoItem = new Graham
                    {
                        Kind = item.Kind,
                        Small = item.Logo.Small,
                        Symbol = item.Symbol,
                        Name = item.Name,
                        CompanyName = item.CompanyName,
                        Sector = item.Sector,
                        Price = item.Price,
                        Yield_12m = item.Financials.Dividends.Yield_12m,
                    };

                    result.Add(novoItem);
                }
            }

            decimal annualGrowthRate = 7.00m;
            decimal returnRate = 1.55m;

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
                AnnualGrowthRate = annualGrowthRate,
                ReturnRate = returnRate,
                Result = p.Yield_12m * (8.5m + (2 * annualGrowthRate)) / returnRate
            }).OrderByDescending(p => p.Result).ToList();

            return result;
        }

        public async Task<IEnumerable<Graham>> GetGrahamMethodologyAsync(IEnumerable<Active> model)
        {
            return await Task.Run(() =>
            {
                List<Graham> result = new List<Graham>();

                foreach (var item in model)
                {
                    if (item.Price != 0 && item.Financials.Dividends.Yield_12m != 0)
                    {
                        var novoItem = new Graham
                        {
                            Kind = item.Kind,
                            Small = item.Logo.Small,
                            Symbol = item.Symbol,
                            Name = item.Name,
                            CompanyName = item.CompanyName,
                            Sector = item.Sector,
                            Price = item.Price,
                            Yield_12m = item.Financials.Dividends.Yield_12m,
                        };

                        result.Add(novoItem);
                    }
                }

                decimal annualGrowthRate = 7.00m;
                decimal returnRate = 1.55m;

                var finalResult = result.Select(p => new Graham
                {
                    Kind = p.Kind,
                    Small = p.Small,
                    Symbol = p.Symbol,
                    Name = p.Name,
                    CompanyName = p.CompanyName,
                    Sector = p.Sector,
                    Price = p.Price,
                    Yield_12m = p.Yield_12m,
                    AnnualGrowthRate = annualGrowthRate,
                    ReturnRate = returnRate,
                    Result = p.Yield_12m * (8.5m + (2 * annualGrowthRate)) / returnRate
                }).OrderByDescending(p => p.Result).ToList();

                return finalResult;
            });
        }
    }
}
