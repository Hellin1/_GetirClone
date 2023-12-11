namespace GetirClone.Domain.Entities
{
    public class ProductCart
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductCartDiscounts>? ProductCartDiscounts { get; set; }

    }
}
