namespace GetirClone.Domain.Entities
{
    public class CardType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string RegexPattern { get; set; }
        public List<PaymentCard>? PaymentCards { get; set; }
        public string CardTypeImageUrl { get; set; }
    }
}
