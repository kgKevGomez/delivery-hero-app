using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryHeroApp.Core
{
    public class MockRouteStopsDataStore : IRouteStopsDataStore
    {
        private RouteStop[] routes = new[]
        {
            new RouteStop(1, "Juan Pérez", new Address("Straat", "123", "3012 CN", "Yellow door"), new [] {
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
            }),
            new RouteStop(2, "Joe Doe", new Address("Straat", "123", "3012 CN", "Yellow door"), new [] {
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
            }),
            new RouteStop(3, "John Smith", new Address("Straat", "123", "3012 CN", "Yellow door"), new [] {
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
            }),
            new RouteStop(4, "Juan Valdéz", new Address("Straat", "123", "3012 CN", "Yellow door"), new [] {
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
            }),
            new RouteStop(5, "Jovel Daan", new Address("Straat", "123", "3012 CN", "Yellow door"), new [] {
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
                new Shipment("123SD4F56G"),
            }),
        };

        public MockRouteStopsDataStore()
        {
            
        }

        public Task<RouteStop> GetRoute(long id)
        {
            return Task.FromResult(routes.FirstOrDefault(r => r.Id == id));
        }

        public Task<RouteStop[]> GetRouteStops()
        {
            
            return Task.FromResult(routes);
        }
    }
}