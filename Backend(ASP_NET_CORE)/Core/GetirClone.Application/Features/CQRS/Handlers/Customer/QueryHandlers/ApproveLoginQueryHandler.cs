using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries.Customer;
using GetirClone.Application.Interfaces;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class ApproveLoginQueryHandler : IRequestHandler<ApproveLoginQuery, UserDto>
    {
        private readonly ICacheService _cacheService;

        public ApproveLoginQueryHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<UserDto> Handle(ApproveLoginQuery request, CancellationToken cancellationToken)
        {
            var dto = new UserDto();
            var cachedUser = _cacheService.Get<UserDto>(request.PhoneNumber);

            if (cachedUser == null)
            {
                dto.IsExist = false;
                return dto;
            }

            if (cachedUser.LastGeneratedCode == request.Code)
            {
                dto.Id = cachedUser.Id;
                dto.Name = cachedUser.Name;
                dto.IsExist = true;
                dto.PhoneNumber = cachedUser.PhoneNumber;
                dto.Email = cachedUser.Email;

                return dto;
            }
            dto.IsExist = true;
            dto.SignInResult = Enums.SignInResultType.WrongCode;
            return dto;
        }
    }
}
