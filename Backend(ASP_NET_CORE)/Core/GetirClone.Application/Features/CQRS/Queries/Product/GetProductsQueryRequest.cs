using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetProductsQueryRequest : IRequest<List<ProductListDto>>
    {

    }
}
