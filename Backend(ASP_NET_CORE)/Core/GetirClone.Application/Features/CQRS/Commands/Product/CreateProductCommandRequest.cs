using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class CreateProductCommand : IRequest<CreatedProductDto>
    {
        public string Title { get; set; }
        public string DimensionsAndCapacity { get; set; }
        public string Details { get; set; } = "";
        public string? Ingredients { get; set; }
        public string? UsageInstructions { get; set; }
        public string? ExtraDetails { get; set; }
        public string? NutritionalInformation { get; set; }
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TotalDiscount { get; set; } = 0;
        public string SKU { get; set; }
        public int Stock { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageUrl { get; set; }
        public int? ParentProductId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int ProductTypeId { get; set; }
    }
}