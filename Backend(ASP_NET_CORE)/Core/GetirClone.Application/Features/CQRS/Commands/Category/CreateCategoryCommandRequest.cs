using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommand : IRequest<CreatedCategoryDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImagePath { get; set; }
        public int? ParentCategoryId { get; set; }
        //public List<Category>? SubCategories { get; set; }
    }
}
