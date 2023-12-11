namespace GetirClone.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int TotalQuantity { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal BagPrice { get; set; } = 0.25m;
        public decimal TotalPrice { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<ProductCart>? ProductCarts { get; set; }
        public List<CartDiscountRelation>? CartDiscountRelations { get; set; }
    }
}