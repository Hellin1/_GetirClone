namespace GetirClone.Domain.Entities
{
    public class ProductCartDiscounts
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public ProductCart ProductCart { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
