using System;
using System.Threading.Tasks;

namespace DeliveryHeroApp.Core
{
    public class MockDataStore : IDataStore<RouteStop>
    {

        public MockDataStore()
        {
            
        }

        public Task<RouteStop[]> GetRouteStops()
        {
            return Task.FromResult(Array.Empty<RouteStop>());
        }
    }
}