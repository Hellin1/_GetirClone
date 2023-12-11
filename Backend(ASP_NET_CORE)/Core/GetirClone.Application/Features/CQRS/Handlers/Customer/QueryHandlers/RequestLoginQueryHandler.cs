using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries.Customer;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class RequestLoginQueryHandler : IRequestHandler<RequestLoginQuery, UserDto>
    {
        private readonly IUow _uow;
        private readonly ICacheService _cacheService;
        private readonly IMessageProducer _messageProducer;
        private readonly IMapper _mapper;
        private static readonly Random random = new Random();

        public RequestLoginQueryHandler(ICacheService cacheService, IUow uow, IMessageProducer messageProducer, IMapper mapper)
        {
            _cacheService = cacheService;
            _uow = uow;
            _messageProducer = messageProducer;
            _mapper = mapper;
        }

        async Task<UserDto> IRequestHandler<RequestLoginQuery, UserDto>.Handle(RequestLoginQuery request, CancellationToken cancellationToken)
        {
            var userDto = new RabbitMQMessageDto();

            var user = _cacheService.Get<UserDto>(request.PhoneNumber);
            if (user == null)
            {
                var userFromDb = await _uow.GetRepository<Customer>().GetByFilterAsync(c => c.PhoneNumber == request.PhoneNumber, cancellationToken);
                user = _mapper.Map<UserDto>(userFromDb);
            }

            if (user != null)
            {
                userDto.Id = user.Id;
                userDto.PhoneNumber = user.PhoneNumber;
                userDto.Email = user.Email;
                userDto.IsExist = true;
                userDto.LastGeneratedCode = GenerateRandomCode(1000, 10000);

                _cacheService.Set<UserDto>(userDto.PhoneNumber, userDto, TimeSpan.FromMinutes(2));
                _messageProducer.SendMessage(userDto);
                return userDto;
            }

            userDto.IsExist = false;
            return userDto;
        }

        static string GenerateRandomCode(int startNumber, int endNumber)
        {
            return $"{random.Next(startNumber, endNumber)}";
        }
    }
}
