using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class PaymentCardListDto
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public string CardNickName { get; set; }
        public string? CardHolderName { get; set; }
        public string? ExpiryDate { get; set; }
        public string? CVV { get; set; }
        public bool IsPrimary { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<Payment>? Payments { get; set; }
        public CardType? CardType { get; set; }
    }
}