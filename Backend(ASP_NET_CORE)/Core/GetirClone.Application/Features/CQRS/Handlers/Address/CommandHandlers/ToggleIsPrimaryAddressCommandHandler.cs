using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class ToggleIsPrimaryAddressCommandHandler : IRequestHandler<ToggleIsPrimaryAddressCommand>
    {
        private readonly IUow _uow;

        public ToggleIsPrimaryAddressCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(ToggleIsPrimaryAddressCommand request, CancellationToken cancellationToken)
        {
            var addressToToggle = await _uow.GetRepository<Address>().GetByFilterAsync(a => a.Id == request.Id, cancellationToken);

            var activeAddress = await _uow.GetRepository<Address>().GetByFilterAsync(a => a.CustomerId == request.CustomerId && a.IsPrimary, cancellationToken);

            if (activeAddress != null)
            {
                activeAddress.IsPrimary = false;
            }


            if (addressToToggle != null)
            {
                addressToToggle.IsPrimary = true;

                await _uow.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
