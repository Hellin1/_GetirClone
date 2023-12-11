using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using MediatR;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                ImagePath = request.ImagePath,
                ParentCategoryId = request.ParentCategoryId == 0 ? null : request.ParentCategoryId,
            };

            var result = await _uow.GetRepository<Category>().CreateAsync(category);
            await _uow.SaveChangesAsync();

            return _mapper.Map<CreatedCategoryDto>(result);
        }
    }
}