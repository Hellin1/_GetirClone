using AutoMapper;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _uow.GetRepository<Product>().GetByIdAsync(request.Id, cancellationToken);
            if (updatedEntity != null)
            {
                updatedEntity.Title = request.Title;
                updatedEntity.DimensionsAndCapacity = request.DimensionsAndCapacity;
                updatedEntity.Details = request.Details;
                updatedEntity.Ingredients = request.Ingredients;
                updatedEntity.UsageInstructions = request.UsageInstructions;
                updatedEntity.ExtraDetails = request.ExtraDetails;
                updatedEntity.NutritionalInformation = request.NutritionalInformation;
                updatedEntity.Description = request.Description;
                updatedEntity.BasePrice = request.BasePrice;
                updatedEntity.SKU = request.SKU;
                updatedEntity.Stock = request.Stock;
                updatedEntity.ImagePath = request.ImagePath;
                updatedEntity.ImageUrl = request.ImageUrl;
                updatedEntity.ParentProductId = request.ParentProductId;
                updatedEntity.BrandId = request.BrandId;
                updatedEntity.CategoryId = request.CategoryId;
                _uow.GetRepository<Product>().Update(updatedEntity);
                await _uow.SaveChangesAsync();
            }
            return Unit.Value;
        }

    }
}