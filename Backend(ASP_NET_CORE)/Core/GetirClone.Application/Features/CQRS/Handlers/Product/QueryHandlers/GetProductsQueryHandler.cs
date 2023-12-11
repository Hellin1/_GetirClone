using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;
using System.Data;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IUow uow, IMapper mapper, IProductRepository productRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductListDto>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsWithCategories(cancellationToken);

            var productDtos = products.Select(p => new ProductListDto
            {
                Id = p.Id,
                Title = p.Title,
                DimensionsAndCapacity = p.DimensionsAndCapacity,
                Details = p.Details,
                Ingredients = p.Ingredients,
                UsageInstructions = p.UsageInstructions,
                ExtraDetails = p.ExtraDetails,
                NutritionalInformation = p.NutritionalInformation,
                Description = p.Description,
                BasePrice = p.BasePrice,
                Price = p.Price,
                TotalDiscount = p.TotalDiscount,
                SKU = p.SKU,
                Stock = p.Stock,
                ImagePath = p.ImagePath,
                ImageUrl = p.ImageUrl,
                ProductType = p.ProductType,

            });

            return _mapper.Map<List<ProductListDto>>(productDtos);
        }
    }
}