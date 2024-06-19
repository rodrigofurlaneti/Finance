using Finance.Web.Models;
using Finance.Web.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class GrahamMethodologyController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = new List<Graham>();

            var allStockExchangeService = new AllStockExchangeService();

            var model = await allStockExchangeService.GetAllActiveAsync();

            foreach (var item in model)
            {
                if (item.Price != 0)
                {
                    if (item.Financials.Dividends.Yield_12m != 0)
                    {
                        result.Add(new Graham
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

            return View(result);
        }
    }
}
