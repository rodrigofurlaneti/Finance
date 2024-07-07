using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface IGrahamMethodologyService
    {
        IEnumerable<Graham> GetGrahamMethodology(IEnumerable<Active> model, IEnumerable<Graham> result);
        Task<IEnumerable<Graham>> GetGrahamMethodologyAsync(IEnumerable<Active> model, IEnumerable<Graham> result);
    }
}
