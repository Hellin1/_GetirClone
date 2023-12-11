namespace GetirClone.Domain.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string MethodName { get; set; }
        public List<PaymentCard> PaymentCards { get; set; }
    }
}
