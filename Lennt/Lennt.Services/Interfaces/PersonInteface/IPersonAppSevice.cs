using Lennt.Dto;
using Lennt.Dto.Person;
using System.Threading.Tasks;

namespace Lennt.Services.Interfaces
{
    public interface IPersonAppSevice
    {
        Task<Lennt.Dto.IResponse<bool>> Register(PersonDto input);
        Task<Lennt.Dto.IResponse<string>> Login(LoginDto input);
        Task<IResponse<PersonDto>> Get();
    }
}
