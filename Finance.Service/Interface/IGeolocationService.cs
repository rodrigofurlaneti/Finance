using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface IGeolocationService
    {
        Task PostAsync(Place place);
    }
}
