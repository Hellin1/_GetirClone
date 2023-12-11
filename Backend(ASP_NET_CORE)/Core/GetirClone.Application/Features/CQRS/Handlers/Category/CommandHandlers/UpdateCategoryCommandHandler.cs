using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IUow _uow;
        private readonly IValidator<UpdateCategoryCommand> _validator;

        public UpdateCategoryCommandHandler(IUow uow, IValidator<UpdateCategoryCommand> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _uow.GetRepository<Category>().GetByIdAsync(request.Id, cancellationToken);
            updatedEntity.Name = request.Name;
            updatedEntity.Description = request.Description;
            updatedEntity.ImageUrl = request.ImageUrl;
            updatedEntity.ImagePath = request.ImagePath;
            updatedEntity.ParentCategoryId = request.ParentCategoryId == 0 ? null : request.ParentCategoryId;

            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}