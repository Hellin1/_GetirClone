namespace GetirClone.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public List<CartDiscountRelation>? CartDiscountRelations { get; set; }
        public List<ProductDiscountRelation>? ProductDiscountRelations { get; set; }
        public List<ProductCartDiscounts>? ProductCartDiscounts { get; set; }
    }
}
