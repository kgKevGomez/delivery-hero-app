using System.Threading.Tasks;

namespace DeliveryHeroApp.Core
{
    public interface IDataStore<T>
    {
        Task<RouteStop[]> GetRouteStops();
    }
}
