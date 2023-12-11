namespace GetirClone.Application.Dto
{
    public class OrderWithoutNavPropsListDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid CustomerId { get; set; }
        public int PaymentId { get; set; }
        public PaymentWithoutNavProps? Payment { get; set; }
        public int ShipmentId { get; set; }
        public ShipmentWithoutNavProps? Shipment { get; set; }
        public List<OrderItemListDto>? OrderItems { get; set; }
    }
}