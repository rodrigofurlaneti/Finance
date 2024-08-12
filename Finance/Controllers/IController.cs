using Finance.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public interface IController
    {
        Task<IActionResult> OrderByDescendingPrice([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByAscendingPrice([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByDescendingChangeLastDay([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByAscendingChangeLastDay([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByDescendingLastDayVariation([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByAscendingLastDayVariation([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByDescendingYieldLastTwelveMonthsPercentage([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByAscendingYieldLastTwelveMonthsPercentage([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByDescendingYieldLastTwelveRealMonths([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByAscendingYieldLastTwelveRealMonths([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByDescendingMarketValue([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> OrderByAscendingMarketValue([FromBody] IEnumerable<Active> returnService);
        Task<IActionResult> Clean();
        Task<IActionResult> RenderTable([FromBody] IEnumerable<Active> updatedModel);
    }
}
