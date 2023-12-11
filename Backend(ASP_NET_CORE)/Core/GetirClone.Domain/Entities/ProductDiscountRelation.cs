namespace GetirClone.Domain.Entities
{
    public class ProductDiscountRelation
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
