using AutoMapper;
using Lennt.Dto.Category;
using Lennt.Dto.Person;
using Lennt.Dto.Vacancy;
using Lennt.Dto.VacancyPerson;
using Lennt.Model.Entities;

namespace Lennt.API
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Vacancy, VacancyDto>().ReverseMap();
            CreateMap<Vacancy, GetVacancyDto>().ReverseMap();
            CreateMap<VacancyPerson, VacancyPersonDto>().ReverseMap();
        }
    }
}
