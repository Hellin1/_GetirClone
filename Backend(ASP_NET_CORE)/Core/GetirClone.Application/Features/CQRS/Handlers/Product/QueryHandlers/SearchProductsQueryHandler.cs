using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsRequest, List<ProductListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IProductRepository _productRepository;

        public SearchProductsQueryHandler(IMapper mapper, IUow uow, IProductRepository productRepository)
        {
            _mapper = mapper;
            _uow = uow;
            _productRepository = productRepository;
        }

        public async Task<List<ProductListDto>> Handle(SearchProductsRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.SearchProductsAsync(request.searchStr, cancellationToken);

            return _mapper.Map<List<ProductListDto>>(result);
        }
    }
}
