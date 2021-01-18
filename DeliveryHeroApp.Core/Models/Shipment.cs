namespace DeliveryHeroApp.Core
{
    public class Shipment
    {
        public string Barcode { get; set; }

        public Shipment(string barcode)
        {
            Barcode = barcode;
        }
    }
}
