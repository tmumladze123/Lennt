using System;
using Lennt.Dto.Vacancy;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lennt.Dto;

namespace Lennt.Services.Interfaces.VacancyInterface
{
	public interface IVacancyAppService
	{
        Task<IResponse<bool>> Create(VacancyDto input);
        Task<IResponse<bool>> Update(VacancyDto input);
        Task<IResponse<GetVacancyDto>> Get(long id);
        Task<IResponse<List<GetVacancyDto>>> GetList();
        
    }
}

