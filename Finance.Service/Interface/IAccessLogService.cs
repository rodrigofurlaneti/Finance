using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface IAccessLogService
    {
        Task<IEnumerable<AccessLog>> GetAsync();
        Task PostAsync(AccessLog accessLog);
    }
}
