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
            return Task.FromResult(new []
            {
                new RouteStop("Juan Pérez", new Address("Straat", "123", "3012 CN", "Yellow door")),
                new RouteStop("Joe Doe", new Address("Straat", "123", "3012 CN", "Yellow door")),
                new RouteStop("John Smith", new Address("Straat", "123", "3012 CN", "Yellow door")),
                new RouteStop("Juan Valdéz", new Address("Straat", "123", "3012 CN", "Yellow door")),
                new RouteStop("Jovel Daan", new Address("Straat", "123", "3012 CN", "Yellow door")),
            });
        }
    }
}