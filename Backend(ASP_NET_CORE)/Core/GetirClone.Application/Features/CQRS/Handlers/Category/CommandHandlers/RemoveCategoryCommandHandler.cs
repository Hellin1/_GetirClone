using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly IUow _uow;

        public RemoveCategoryCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _uow.GetRepository<Category>().GetByIdAsync(request.Id, cancellationToken);

            _uow.GetRepository<Category>().Remove(category);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
