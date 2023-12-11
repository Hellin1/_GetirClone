namespace GetirClone.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Address>? Addresses { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Wishlist>? Wishlist { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }
        public List<Payment>? Payments { get; set; }
        public List<PaymentCard>? PaymentCards { get; set; }
        public List<Shipment>? Shipments { get; set; }
    }
}