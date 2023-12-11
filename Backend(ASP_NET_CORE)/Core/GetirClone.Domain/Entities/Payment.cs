namespace GetirClone.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DeliveryFee { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int? PaymentCardId { get; set; }
        public PaymentCard? PaymentCard { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
