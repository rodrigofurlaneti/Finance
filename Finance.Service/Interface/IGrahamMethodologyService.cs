using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface IGrahamMethodologyService
    {
        IEnumerable<Graham> GetGrahamMethodology(IEnumerable<Active> model);
        Task<IEnumerable<Graham>> GetGrahamMethodologyAsync(IEnumerable<Active> model);
    }
}
