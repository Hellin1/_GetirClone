using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetProductByIdQueryRequest : IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetProductByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
