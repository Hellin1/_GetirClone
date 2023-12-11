using GetirClone.Domain.Entities;

namespace GetirClone.Application.Dto
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImagePath { get; set; }
        public int ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Category>? SubCategories { get; set; }
        public List<ProductListDto>? Products { get; set; }
    }
}