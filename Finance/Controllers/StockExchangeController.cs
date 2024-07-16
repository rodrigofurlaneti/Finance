using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace Finance.Web.Controllers
{
    public class StockExchangeController : Controller
    {
        private readonly IStockExchangeService _stockExchangeService;

        public StockExchangeController(IStockExchangeService stockExchangeService)
        {
            _stockExchangeService = stockExchangeService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var items = await _stockExchangeService.GetStockExchangeActiveAsync();

            int pageSize = 40; // Tamanho da página

            int pageNumber = (page ?? 1); // Número da página atual

            return View(items.ToPagedList(pageNumber, pageSize));

        }
    }
}
