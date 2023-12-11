using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQueryRequest, CustomerListDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CustomerListDto> Handle(GetCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await _uow.GetRepository<Customer>().GetByIdAsync(request.Id, cancellationToken);

            return _mapper.Map<CustomerListDto>(customer);
        }
    }
}
