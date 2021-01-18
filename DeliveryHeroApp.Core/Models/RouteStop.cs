using System;

namespace DeliveryHeroApp.Core
{
    public class RouteStop
    {
        public RouteStop(long id, string customerName, Address address, Shipment[] shipments)
        {
            Id = id;
            CustomerName = customerName;
            Address = address;
            Shipments = shipments;
        }

        public long Id { get; }
        public string CustomerName { get; set; }
        public Address Address { get; set; }
        public Shipment[] Shipments { get; set; }

    }
}
