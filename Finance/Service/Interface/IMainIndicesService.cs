using Finance.Models;

namespace Finance.Web.Service.Interface
{
    public interface IMainIndicesService
    {
        Task<Trend> GetMainIndicesServiceAsync(Routes.Route route);
    }
}
