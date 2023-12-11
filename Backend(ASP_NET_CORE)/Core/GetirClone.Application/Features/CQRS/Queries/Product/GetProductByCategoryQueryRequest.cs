using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class GetProductByCategoryQueryRequest : IRequest<Object>
    {
        public int CategoryId { get; set; }

        public GetProductByCategoryQueryRequest(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
