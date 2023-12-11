using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, List<OrderWithoutNavPropsListDto>>
    {
        private readonly IUow _uow;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IUow uow, IMapper mapper, IOrderRepository orderRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderWithoutNavPropsListDto>> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersWithNavProps(request.CustomerId, DateTime.UtcNow.Year, cancellationToken);

            return _mapper.Map<List<OrderWithoutNavPropsListDto>>(orders);
        }
    }
}
