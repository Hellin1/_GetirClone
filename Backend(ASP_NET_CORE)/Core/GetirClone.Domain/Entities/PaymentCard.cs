namespace GetirClone.Domain.Entities
{
    public class PaymentCard
    {
        public int Id { get; set; }
        public DateTime LastPrimaryDate { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string CardNickName { get; set; }
        public string ExpiryDate { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsPassive { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<Payment>? Payments { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public int CardTypeId { get; set; }
        public CardType? CardType { get; set; }
    }
}
