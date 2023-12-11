using MediatR;

namespace GetirClone.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImagePath { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
