using Finance.Domain;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class BrazilianDepositaryReceiptsController : Controller, IController
    {
        private readonly IBrazilianDepositaryReceiptsService _brazilianDepositaryReceiptsService;

        public BrazilianDepositaryReceiptsController(IBrazilianDepositaryReceiptsService brazilianDepositaryReceiptsService)
        {
            _brazilianDepositaryReceiptsService = brazilianDepositaryReceiptsService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _brazilianDepositaryReceiptsService.GetAllActiveBdrAsync();

            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingPrice([FromBody] IEnumerable<Active> returnService)
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
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingPrice([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.Price).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingChangeLastDay([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.ChangePercent).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByDescendingChangeLastDay: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingChangeLastDay([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.ChangePercent).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByAscendingChangeLastDay: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingLastDayVariation([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.ChangePrice).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByDescendingLastDayVariation: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingLastDayVariation([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.ChangePrice).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByAscendingLastDayVariation: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingYieldLastTwelveMonthsPercentage([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.Financials.Dividends.Yield_12m).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByDescendingYieldLastTwelveMonthsPercentage: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingYieldLastTwelveMonthsPercentage([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.Financials.Dividends.Yield_12m).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByAscendingYieldLastTwelveMonthsPercentage: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingYieldLastTwelveRealMonths([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.Financials.Dividends.Yield_12m_sum).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByDescendingYieldLastTwelveMonthsPercentage: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingYieldLastTwelveRealMonths([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.Financials.Dividends.Yield_12m_sum).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByAscendingYieldLastTwelveMonthsPercentage: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingMarketValue([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.MarketCap).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByDescendingMarketValue: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingMarketValue([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.MarketCap).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in BrazilianDepositaryReceipts/OrderByAscendingMarketValue: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Clean()
        {
            try
            {
                var model = await _brazilianDepositaryReceiptsService.GetAllActiveBdrAsync();

                return Json(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in BrazilianDepositaryReceipts/Clean: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RenderTable([FromBody] IEnumerable<Active> updatedModel)
        {
            try
            {
                // Renderizar a partial view de forma assíncrona
                var partialViewResult = await Task.Run(() => PartialView("_TabelaBrazilian", updatedModel));

                return partialViewResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in BrazilianDepositaryReceipts/RenderTable: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }
    }
}
