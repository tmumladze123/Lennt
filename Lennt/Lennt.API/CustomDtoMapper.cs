using AutoMapper;
using Lennt.Dto.Category;
using Lennt.Dto.Person;
using Lennt.Model.Entities;

namespace Lennt.API
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
