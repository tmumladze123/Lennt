using System.Collections.Generic;
using System.Threading.Tasks;
using Lennt.Dto;
using Lennt.Dto.Category;

namespace Lennt.Services.Interfaces
{
    public interface ICategoryAppService
    {
        Task<IResponse<List<CategoryDto>>> Get();
    }
}
