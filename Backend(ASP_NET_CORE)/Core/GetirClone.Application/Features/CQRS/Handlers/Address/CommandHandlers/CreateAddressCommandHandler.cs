using AutoMapper;
using FluentValidation;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedEntityDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAddressCommand> _validator;

        public CreateAddressCommandHandler(IUow uow, IMapper mapper, IValidator<CreateAddressCommand> validator)
        {
            _uow = uow;
            _mapper = mapper;
            _validator = validator;
        }

        async Task<CreatedEntityDto> IRequestHandler<CreateAddressCommand, CreatedEntityDto>.Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var activeAddress = await _uow.GetRepository<Address>().GetByFilterAsync(a => a.IsPrimary && a.CustomerId == request.CustomerId, cancellationToken);


            if (activeAddress != null) activeAddress.IsPrimary = false;

            var address = new Address
            {
                Title = request.Title,
                AddressString = request.AddressString,
                BuildingNumber = request.BuildingNumber,
                Floor = request.Floor,
                ApartmentNumber = request.ApartmentNumber,
                AddressDirections = request.AddressDirections,
                AddressTypeId = request.AddressTypeId,
                AddressImageId = request.AddressImageId,
                CustomerId = request.CustomerId,
                IsPrimary = true,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
            };


            var result = await _uow.GetRepository<Address>().CreateAsync(address);
            await _uow.SaveChangesAsync();

            return _mapper.Map<CreatedEntityDto>(result);
        }
    }
}