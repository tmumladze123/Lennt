using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lennt.Dto;
using Lennt.Dto.Category;
using Lennt.Model;
using Lennt.Services.Interfaces;

namespace Lennt.Services.Service
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly LenntDbContext _db;
        private readonly IMapper _mapper;
        public CategoryAppService(
            LenntDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IResponse<List<CategoryDto>>> Get()
        {
            return new ResponseModel<List<CategoryDto>>()
            {
                Data =
                _mapper.Map<List<CategoryDto>>(_db.Categories.Where(x => x.Id >= 0).ToList())
            };
        }
    }
}
