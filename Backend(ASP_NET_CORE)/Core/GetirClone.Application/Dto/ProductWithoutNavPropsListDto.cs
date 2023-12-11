namespace GetirClone.Application.Dto
{
    public class ProductWithoutNavPropsListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
