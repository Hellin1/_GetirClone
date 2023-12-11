namespace GetirClone.Application.Dto
{
    public class OrderItemListDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductWithoutNavPropsListDto Product { get; set; }
    }
}

