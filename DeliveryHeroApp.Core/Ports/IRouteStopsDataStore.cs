using System.Threading.Tasks;

namespace DeliveryHeroApp.Core
{
    public interface IRouteStopsDataStore
    {
        Task<RouteStop[]> GetRouteStops();
        Task<RouteStop> GetRoute(long id);
    }
}
