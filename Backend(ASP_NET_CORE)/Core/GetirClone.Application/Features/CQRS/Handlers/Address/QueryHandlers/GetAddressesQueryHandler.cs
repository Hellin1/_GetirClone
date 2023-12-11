using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQueryRequest, List<AddressListDto>>
    {
        private readonly IUow _uow;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetAddressesQueryHandler(IUow uow, IMapper mapper, IAddressRepository addressRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<List<AddressListDto>> Handle(GetAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAddresses(request.CustomerId, cancellationToken);

            return _mapper.Map<List<AddressListDto>>(addresses);
        }

    }
}
