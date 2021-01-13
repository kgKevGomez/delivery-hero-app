using System;

namespace DeliveryHeroApp.Core
{
    public class RouteStop
    {
        public string CustomerName { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string Remarks { get; set; }
    }
}
