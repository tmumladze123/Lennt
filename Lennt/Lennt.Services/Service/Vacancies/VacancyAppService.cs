using System.Collections.Generic;
using System.Threading.Tasks;
using Lennt.Dto;
using Lennt.Model.Entities;
using Lennt.Dto.Vacancy;
using Lennt.Services.Interfaces.VacancyInterface;
using AutoMapper;
using System.Linq;
using Lennt.Model;

namespace Lennt.Services.Service.Vacancies
{
	public class VacancyAppService : IVacancyAppService
	{
        private readonly LenntDbContext _db;
        private readonly IMapper _mapper;
        public VacancyAppService(
            LenntDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IResponse<GetVacancyDto>> Get(long id)
        {
            return new ResponseModel<GetVacancyDto>()
            {
                Data =
                _mapper.Map<GetVacancyDto>(_db.Vacancies.FirstOrDefault(x => x.Id == id))
            };
        }
        public async Task<IResponse<List<GetVacancyDto>>> GetList()
        {
            return new ResponseModel<List<GetVacancyDto>>()
            {
                Data =
                _mapper.Map<List<GetVacancyDto>>(_db.Vacancies.Where(x => x.IsFinished == false).ToList())
            };
        }
        public async Task<IResponse<bool>> Create(VacancyDto input)
        {
            var vacancy = _mapper.Map<Vacancy>(input);
            _db.Add(vacancy);
            _db.SaveChanges();
            return new ResponseModel<bool>() { Data = true };
        }

        public async Task<IResponse<bool>> Update(VacancyDto input)
        {

            var vacancy = _db.Vacancies.FirstOrDefault(x => x.Id == input.Id);
            if (vacancy != null)
            {
                _mapper.Map(input, vacancy);
            }

            _db.Update(vacancy);
            _db.SaveChanges();
            return new ResponseModel<bool>() { Data = true };
        }

      
    }
}

