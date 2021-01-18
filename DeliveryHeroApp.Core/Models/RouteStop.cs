using System;

namespace DeliveryHeroApp.Core
{
    public class RouteStop
    {
        public RouteStop(string customerName, Address address)
        {
            CustomerName = customerName;
            Address = address;
        }

        public string CustomerName { get; set; }
        public Address Address { get; set; }
    }
}
