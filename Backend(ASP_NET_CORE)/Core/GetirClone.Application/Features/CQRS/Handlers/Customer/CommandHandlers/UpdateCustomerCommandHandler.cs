using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IUow _uow;

        public UpdateCustomerCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _uow.GetRepository<Customer>().GetByIdAsync(request.Id, cancellationToken);
            updatedEntity.Name = request.Name;
            updatedEntity.Email = request.Email;
            updatedEntity.PhoneNumber = request.PhoneNumber;

            _uow.GetRepository<Customer>().Update(updatedEntity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }

    }
}