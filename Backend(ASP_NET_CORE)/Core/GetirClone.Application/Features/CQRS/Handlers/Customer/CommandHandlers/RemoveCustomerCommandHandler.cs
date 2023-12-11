using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand>
    {
        private readonly IUow _uow;

        public RemoveCustomerCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _uow.GetRepository<Customer>().GetByIdAsync(request.Id, cancellationToken);

            if (customer != null)
            {
                _uow.GetRepository<Customer>().Remove(customer);
                await _uow.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
