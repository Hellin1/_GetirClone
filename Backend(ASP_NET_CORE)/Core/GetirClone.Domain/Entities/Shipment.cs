namespace GetirClone.Domain.Entities
{
    public class Shipment
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public List<Order> Orders { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ShipmentStateId { get; set; }
        public ShipmentStates ShipmentState { get; set; }
    }
}
