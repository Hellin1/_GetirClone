using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommand>
    {
        private readonly IUow _uow;

        public RemoveAddressCommandHandler(IUow uow)
        {
            _uow = uow;
        }
        public async Task<Unit> Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _uow.GetRepository<Address>().GetByIdAsync(request.Id, cancellationToken);

            if (address == null) return Unit.Value;

            if (address.IsPrimary)
            {
                var newActiveAddress = _uow.GetRepository<Address>().GetQuery().
                    OrderByDescending(a => a.LastPrimaryDate).
                    Where(a => a.Id != request.Id && a.CustomerId == request.CustomerId).
                    FirstOrDefault();

                if (newActiveAddress != null)
                    newActiveAddress.IsPrimary = true;

            }


            _uow.GetRepository<Address>().Remove(address);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
