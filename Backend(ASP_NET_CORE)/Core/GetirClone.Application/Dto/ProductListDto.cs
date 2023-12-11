using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DimensionsAndCapacity { get; set; }
        public string? Details { get; set; }
        public string? Ingredients { get; set; }
        public string? UsageInstructions { get; set; }
        public string? ExtraDetails { get; set; }
        public string? NutritionalInformation { get; set; }
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        public decimal? TotalDiscount { get; set; }
        public string? SKU { get; set; }
        public int? Stock { get; set; }
        public string ImagePath { get; set; }
        public string ImageUrl { get; set; }
        public List<ProductListDto>? ChildProducts { get; set; }
        public ProductType? ProductType { get; set; }
    }
}