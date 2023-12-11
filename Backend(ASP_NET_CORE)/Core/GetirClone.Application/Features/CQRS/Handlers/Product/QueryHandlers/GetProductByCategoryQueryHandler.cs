using AutoMapper;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQueryRequest, Object>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;


        public GetProductByCategoryQueryHandler(IUow uow, IMapper mapper, IProductRepository productRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        async Task<Object> IRequestHandler<GetProductByCategoryQueryRequest, Object>.Handle(GetProductByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProductsByCategory(request.CategoryId, cancellationToken);
            return result;
        }
    }
}
