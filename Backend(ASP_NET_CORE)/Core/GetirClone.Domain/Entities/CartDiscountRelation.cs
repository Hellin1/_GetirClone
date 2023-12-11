namespace GetirClone.Domain.Entities
{
    public class CartDiscountRelation
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
