using Lennt.Dto;
using Lennt.Dto.Person;
using Lennt.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lennt.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("LenntOrigins")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonAppSevice _Service;
        public PersonController(IPersonAppSevice service)
        {
            _Service = service;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IResponse<bool>> Register([FromBody] PersonDto input)
        {
            var result = _Service.Register(input);
            return await result;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IResponse<string>> Login([FromBody] LoginDto input)
        {
            var result = _Service.Login(input);
            return await result;

        }
        [HttpGet]
        public async Task<IResponse<PersonDto>> Get()
        {
            var result = _Service.Get();
            return await result;
        }
    }
}
