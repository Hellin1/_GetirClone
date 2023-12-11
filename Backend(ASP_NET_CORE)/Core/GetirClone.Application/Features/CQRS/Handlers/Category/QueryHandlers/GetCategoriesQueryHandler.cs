using AutoMapper;
using GetirClone.Application.Consts;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IUow _uow;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetCategoriesQueryHandler(IUow uow, IMapper mapper, ICategoryRepository categoryRepository, ICacheService cacheService)
        {
            _uow = uow;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _cacheService = cacheService;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categoriesWithNavProps = _cacheService.GetList<Category>(CacheConstants.CategoriesWithNavProps);
            if (categoriesWithNavProps == null || categoriesWithNavProps.Count == 0)
            {
                categoriesWithNavProps = await _categoryRepository.GetAllCategoriesWithSubCategories(cancellationToken);

                _cacheService.SetList<Category>(CacheConstants.CategoriesWithNavProps, categoriesWithNavProps);
            }

            return _mapper.Map<List<CategoryListDto>>(categoriesWithNavProps);
        }
    }
}
