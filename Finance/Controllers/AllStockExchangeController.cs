using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace Finance.Web.Controllers
{
    public class AllStockExchangeController : Controller
    {
        private readonly IAllStockExchangeService _allStockExchangeService;

        public AllStockExchangeController(IAllStockExchangeService allStockExchangeService)
        {
            _allStockExchangeService = allStockExchangeService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var items = await _allStockExchangeService.GetAllActiveAsync();

            int pageSize = 100; // Tamanho da página

            int pageNumber = (page ?? 1); // Número da página atual

            return View(items.ToPagedList(pageNumber, pageSize));
        }


    }
}
