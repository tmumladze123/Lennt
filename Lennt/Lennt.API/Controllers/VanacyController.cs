using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Lennt.Services.Interfaces.VacancyInterface;
using Lennt.Dto.Vacancy;
using Lennt.Dto;

namespace Lennt.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VanacyController : Controller
    {
        private readonly IVacancyAppService _Service;
        public VanacyController(IVacancyAppService service)
        {
            _Service = service;
        }
        [HttpPost]
        public async Task<IResponse<bool>> Create([FromBody] VacancyDto input, long userId)
        {
            var result = _Service.Create(input, userId);
            return await result;
        }
        [HttpPost]
        public async Task<IResponse<bool>> Approve(long vacancyId)
        {
            var result = _Service.Approve(vacancyId);
            return await result;
        }
        [HttpPost]
        public async Task<IResponse<bool>> ApproveByOwner(long vacancyId, long personId)
        {
            var result = _Service.ApproveByOwner(vacancyId, personId);
            return await result;
        }

        [HttpPut]
        public async Task<IResponse<bool>> Update([FromBody] VacancyDto input)
        {
            var result = _Service.Update(input);
            return await result;

        }
        [HttpGet]
        public async Task<IResponse<GetVacancyDto>> Get(long id)
        {
            var result = _Service.Get(id);
            return await result;
        }
        [HttpGet]
        public async Task<IResponse<List<GetVacancyDto>>> GetList()
        {
            var result = _Service.GetList();
            return await result;
        }

        [HttpGet]
        public async Task<IResponse<List<GetVacancyDto>>> GetMyVacancies()
        {
            var result = _Service.GetMyVacancies();
            return await result;
        }
        [HttpGet]
        public async Task<IResponse<List<GetVacancyDto>>> GetMyOffers()
        {
            var result = _Service.GetMyOffers();
            return await result;
        }
    }
}

