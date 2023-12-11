using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IUow _uow;

        public RemoveProductCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var removedEntity = await _uow.GetRepository<Product>().GetByIdAsync(request.Id, cancellationToken);
            if (removedEntity != null)
            {
                _uow.GetRepository<Product>().Remove(removedEntity);
                await _uow.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
