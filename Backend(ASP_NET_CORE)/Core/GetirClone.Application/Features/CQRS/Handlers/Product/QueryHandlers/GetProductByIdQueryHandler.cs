using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, ProductListDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IUow uow, IMapper mapper, IProductRepository productRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductListDto> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductWithCategory(request.Id, cancellationToken);

            return _mapper.Map<ProductListDto>(product);
        }
    }
}
