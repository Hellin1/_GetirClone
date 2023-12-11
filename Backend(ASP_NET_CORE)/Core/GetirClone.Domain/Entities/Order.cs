namespace GetirClone.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int TotalAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool DontRingBell { get; set; }
        public string? Note { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}
