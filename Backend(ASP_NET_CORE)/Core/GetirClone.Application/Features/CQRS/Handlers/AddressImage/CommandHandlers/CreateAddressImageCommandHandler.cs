using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateAddressImageCommandHandler : IRequestHandler<CreateAddressImageCommand>
    {
        private readonly IUow _uow;

        public CreateAddressImageCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateAddressImageCommand command, CancellationToken cancellationToken)
        {
            var ImageEntity = new AddressImage
            {
                ImageString = command.ImageString,
                ImageUrl = command.ImageUrl,
                Title = command.Title,
            };

            await _uow.GetRepository<AddressImage>().CreateAsync(ImageEntity);

            return Unit.Value;
        }
    }
}
