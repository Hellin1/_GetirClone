using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, CategoryListDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _uow.GetRepository<Category>().GetByIdAsync(request.Id, cancellationToken);

            return _mapper.Map<CategoryListDto>(category);
        }
    }
}
