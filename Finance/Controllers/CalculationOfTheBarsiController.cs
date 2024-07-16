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
            try
            {
                var model = _allStockExchangeService.GetAllActive();

                var returmService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(model);

                return View(returmService);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/Index: " + ex.Message);
                
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> OrderByDescendingYield()
        {
            try
            {
                var model = _allStockExchangeService.GetAllActive();

                var returmService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(model);

                // Ordenar a lista pela coluna Yield em ordem decrescente
                returmService = returmService.OrderByDescending(b => b.Yield_12m).ToList();

                return PartialView("_TabelaBarsi", returmService);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByDescendingYield: " + ex.Message);
                
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> OrderByAscendingYield()
        {
            try
            {
                var model = _allStockExchangeService.GetAllActive();

                var returnService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(model);

                var orderedModel = returnService.OrderBy(b => b.Yield_12m).ToList();

                return PartialView("_TabelaBarsi", orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> OrderByDescendingPrice()
        {
            try
            {
                var model = _allStockExchangeService.GetAllActive();

                var returmService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(model);

                // Ordenar a lista pela coluna Yield em ordem decrescente
                returmService = returmService.OrderByDescending(b => b.Price).ToList();

                return PartialView("_TabelaBarsi", returmService);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> OrderByAscendingPrice()
        {
            try
            {
                var model = _allStockExchangeService.GetAllActive();

                var returnService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(model);

                var orderedModel = returnService.OrderBy(b => b.Price).ToList();

                return PartialView("_TabelaBarsi", orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> OrderByDescendingResult()
        {
            try
            {
                var model = _allStockExchangeService.GetAllActive();

                var returmService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(model);

                // Ordenar a lista pela coluna Yield em ordem decrescente
                returmService = returmService.OrderByDescending(b => b.Result).ToList();

                return PartialView("_TabelaBarsi", returmService);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> OrderByAscendingResult()
        {
            try
            {
                var model = _allStockExchangeService.GetAllActive();

                var returnService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(model);

                var orderedModel = returnService.OrderBy(b => b.Result).ToList();

                return PartialView("_TabelaBarsi", orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

    }
}
