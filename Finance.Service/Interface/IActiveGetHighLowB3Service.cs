using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface IActiveGetHighLowB3Service
    {
        Task<IEnumerable<Active>> GetAllActiveHighLowB3Async();
    }
}
