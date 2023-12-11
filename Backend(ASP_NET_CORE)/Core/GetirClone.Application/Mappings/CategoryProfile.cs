using AutoMapper;
using GetirClone.Application.Dto;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CreatedCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
