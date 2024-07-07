using Finance.Domain;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class GrahamMethodologyController : Controller
    {
        private readonly IAllStockExchangeService _allStockExchangeService;
        private readonly IGrahamMethodologyService _grahamMethodologyService;

        public GrahamMethodologyController(IAllStockExchangeService allStockExchangeService, 
            IGrahamMethodologyService grahamMethodologyService)
        {
            _allStockExchangeService = allStockExchangeService;
            _grahamMethodologyService = grahamMethodologyService;
        }

        public async Task<IActionResult> Index()
        {
            var result = new List<Graham>();

            var model = await _allStockExchangeService.GetAllActiveAsync();

            var resultService = _grahamMethodologyService.GetGrahamMethodology(model, result);

            return View(resultService);
        }
    }
}
