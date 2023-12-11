namespace GetirClone.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public DateTime LastPrimaryDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Title { get; set; }
        public string AddressString { get; set; }
        public string BuildingNumber { get; set; }
        public string Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public string AddressDirections { get; set; }
        public bool IsPrimary { get; set; }
        public int AddressTypeId { get; set; }
        public AddressType? AddressType { get; set; }
        public int AddressImageId { get; set; }
        public AddressImage? AddressImage { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Shipment>? Shipments { get; set; }
    }
}
