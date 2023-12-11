using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetCategoryByIdQueryRequest : IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetCategoryByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
