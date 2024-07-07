using Finance.Domain;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class CalculationOfTheBarsiController : Controller
    {
        private readonly ICalculationOfTheBarsiService _calculationOfTheBarsiService;
        private readonly IAllStockExchangeService _allStockExchangeService;

        public CalculationOfTheBarsiController(ICalculationOfTheBarsiService calculationOfTheBarsiService, 
            IAllStockExchangeService allStockExchangeServiceService)
        {
            _calculationOfTheBarsiService = calculationOfTheBarsiService;
            _allStockExchangeService = allStockExchangeServiceService;
        }

        public async Task<IActionResult> Index()
        {
            var result = new List<Barsi>();

            var model = await _allStockExchangeService.GetAllActiveAsync();

            var returmService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(model, result);

            return View(returmService);
        }
    }
}
