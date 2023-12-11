using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class PaymentWithoutNavProps
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public Guid CustomerId { get; set; }

        public int? PaymentCardId { get; set; }

        public PaymentCard? PaymentCard { get; set; }
    }
}

