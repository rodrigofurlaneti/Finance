using Finance.Domain;

namespace Finance.Data.Interface
{
    public interface IAccessLogData
    {
        Task<IEnumerable<AccessLog>> GetAsync();
        Task PostAsync(AccessLog accessLog);
    }
}
