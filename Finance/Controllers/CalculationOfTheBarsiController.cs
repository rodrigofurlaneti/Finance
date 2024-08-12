using Finance.Domain;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingYield([FromBody] IEnumerable<Barsi> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.Yield_12m).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByDescendingYield: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingYield([FromBody] IEnumerable<Barsi> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.Yield_12m).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingPrice([FromBody] IEnumerable<Barsi> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.Price).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingPrice([FromBody] IEnumerable<Barsi> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.Price).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingResult([FromBody] IEnumerable<Barsi> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.Result_Year).ToList());
                
                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingResult([FromBody] IEnumerable<Barsi> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.Result_Year).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByKindFii([FromBody] IEnumerable<Barsi> model)
        {
            try
            {
                model = model.Where(b => b.Kind.Equals("fii")).ToList();

                if (model.Count().Equals(0))
                {
                    var modelResult = _allStockExchangeService.GetAllActive();

                    var returnService = _calculationOfTheBarsiService.GetCalculationOfTheBarsi(modelResult);

                    model = returnService.Where(b => b.Kind.Equals("fii")).ToList();
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByKindFii: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByKindStock([FromBody] IEnumerable<Barsi> model)
        {
            try
            {
                model = model.Where(b => b.Kind.Equals("stock")).ToList();

                if (model.Count().Equals(0))
                {
                    var modelResult = await _allStockExchangeService.GetAllActiveAsync();

                    var returnService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(modelResult);

                    model = returnService.Where(b => b.Kind.Equals("stock")).ToList();
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByKindStock: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByKindBdr([FromBody] IEnumerable<Barsi> model)
        {
            try
            {
                model = model.Where(b => b.Kind.Equals("bdr")).ToList();

                if(model.Count().Equals(0))
                {
                    var modelResult = await _allStockExchangeService.GetAllActiveAsync();

                    var returnService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(modelResult);

                    model = returnService.Where(b => b.Kind.Equals("bdr")).ToList();
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in CalculationOfTheBarsiController/OrderByKindStock: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Clean()
        {
            try
            {
                var model = await _allStockExchangeService.GetAllActiveAsync();

                var returmService = await _calculationOfTheBarsiService.GetCalculationOfTheBarsiAsync(model);
                
                return Json(returmService);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CalculationOfTheBarsiController/Clean: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RenderTable([FromBody] IEnumerable<Barsi> updatedModel)
        {
            try
            {
                // Renderizar a partial view de forma assíncrona
                var partialViewResult = await Task.Run(() => PartialView("_TabelaBarsi", updatedModel));

                return partialViewResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CalculationOfTheBarsiController/RenderTable: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
