namespace DeliveryHeroApp.Core
{
    public class Address
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string Remarks { get; set; }

        public Address(string street, string houseNumber, string postalCode, string remarks)
        {
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            Remarks = remarks;
        }

        public override string ToString()
        {
            return $"{Street} {HouseNumber}, {PostalCode}";
        }
    }
}
