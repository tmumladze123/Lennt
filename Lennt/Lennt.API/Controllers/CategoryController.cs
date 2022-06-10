using System.Collections.Generic;
using System.Threading.Tasks;
using Lennt.Dto;
using Lennt.Dto.Category;
using Lennt.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Lennt.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _Service;
        public CategoryController(ICategoryAppService service)
        {
            _Service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IResponse<List<CategoryDto>>> Get()
        {
            var result = _Service.Get();
            return await result;
        }
    }
}
