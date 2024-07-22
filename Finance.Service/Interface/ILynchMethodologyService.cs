using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface ILynchMethodologyService
    {
        IEnumerable<Lynch> GetLynchMethodology(IEnumerable<Active> model);
        Task<IEnumerable<Lynch>> GetLynchMethodologyAsync(IEnumerable<Active> model);
    }
}
