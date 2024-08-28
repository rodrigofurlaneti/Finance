using Finance.Domain;

namespace Finance.Data.Interface
{
    public interface IActiveGetHighLowB3Data
    {
        Task<IEnumerable<Active>> GetAllActiveHighLowB3Async();
    }
}
