using Finance.Domain;
using Finance.Service.Interface;

namespace Finance.Service.Implementation
{
    public class LynchMethodologyService : ILynchMethodologyService
    {
        public IEnumerable<Lynch> GetLynchMethodology(IEnumerable<Active> model)
        {
            List<Lynch> result = new List<Lynch>();

            foreach (var item in model)
            {
                var earningsPerShare = 15;

                var growthRate = 0.10m;

                if (item.Price != 0 && earningsPerShare != 0 && growthRate != 0)
                {
                    decimal peRatio = item.Price / earningsPerShare;
                    decimal pegRatio = peRatio / growthRate;

                    var novoItem = new Lynch
                    {
                        Kind = item.Kind,
                        Small = item.Logo.Small,
                        Symbol = item.Symbol,
                        Name = item.Name,
                        CompanyName = item.CompanyName,
                        Sector = item.Sector,
                        Price = item.Price,
                        EarningsPerShare = earningsPerShare,
                        GrowthRate = growthRate,
                        PERatio = peRatio,
                        PEGRatio = pegRatio
                    };

                    result.Add(novoItem);
                }
            }

            return result.OrderBy(p => p.PEGRatio).ToList();
        }

        public async Task<IEnumerable<Lynch>> GetLynchMethodologyAsync(IEnumerable<Active> model)
        {
            return await Task.Run(() => GetLynchMethodology(model));
        }
    }
}
