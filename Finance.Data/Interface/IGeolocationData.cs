using Finance.Domain;

namespace Finance.Data.Interface
{
    public interface IGeolocationData
    {
        Task PostAsync(Place place);
    }
}
