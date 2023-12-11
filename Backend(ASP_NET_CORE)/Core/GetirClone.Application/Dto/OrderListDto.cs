using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}
