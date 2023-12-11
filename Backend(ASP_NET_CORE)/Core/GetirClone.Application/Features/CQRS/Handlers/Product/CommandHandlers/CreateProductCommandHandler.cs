using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Title = request.Title,
                DimensionsAndCapacity = request.DimensionsAndCapacity,
                Details = request.Details,
                Ingredients = request.Ingredients,
                UsageInstructions = request.UsageInstructions,
                ExtraDetails = request.ExtraDetails,
                NutritionalInformation = request.NutritionalInformation,
                Description = request.Description,
                BasePrice = request.BasePrice,
                Price = request.BasePrice,

                SKU = request.SKU,
                Stock = request.Stock,
                ImagePath = request.ImagePath,
                ImageUrl = request.ImageUrl,
                ParentProductId = request.ParentProductId,
                ProductTypeId = request.ProductTypeId,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
            };

            if (request.ParentProductId == 0) product.ParentProductId = null;

            var result = await _uow.GetRepository<Product>().CreateAsync(product);
            await _uow.SaveChangesAsync();

            return _mapper.Map<CreatedProductDto>(result);
        }
    }
}
