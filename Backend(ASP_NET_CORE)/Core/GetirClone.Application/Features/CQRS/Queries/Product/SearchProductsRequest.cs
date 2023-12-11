using GetirClone.Application.Dto;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Queries
{
    public class SearchProductsRequest : IRequest<List<ProductListDto>>
    {
        public string searchStr { get; set; }

        public SearchProductsRequest(string searchStr)
        {
            this.searchStr = searchStr;
        }
    }
}
