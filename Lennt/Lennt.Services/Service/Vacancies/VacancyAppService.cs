using System.Collections.Generic;
using System.Threading.Tasks;
using Lennt.Dto;
using Lennt.Model.Entities;
using Lennt.Dto.Vacancy;
using Lennt.Services.Interfaces.VacancyInterface;
using AutoMapper;
using System.Linq;
using Lennt.Model;
using Lennt.Dto.VacancyPerson;
using Lennt.Services.Interfaces;

namespace Lennt.Services.Service.Vacancies
{
    public class VacancyAppService : IVacancyAppService
    {
        private readonly LenntDbContext _db;
        private readonly IMapper _mapper;
        private readonly IJwtPasswordInterface _jwtPasswordService;
        public VacancyAppService(
            LenntDbContext db,
            IMapper mapper,
            IJwtPasswordInterface jwtPasswordInterface)
        {
            _db = db;
            _mapper = mapper;
            _jwtPasswordService = jwtPasswordInterface;
        }
        public async Task<IResponse<GetVacancyDto>> Get(long id)
        {
            return new ResponseModel<GetVacancyDto>()
            {
                Data =
                _mapper.Map<GetVacancyDto>(_db.Vacancies.FirstOrDefault(x => x.Id == id))
            };
        }
        public async Task<IResponse<GetMyVacanciesDto>> GetMyVacanciesDetails(long id)
        {
            var vacancy = _mapper.Map<GetVacancyDto>(_db.Vacancies.FirstOrDefault(x => x.Id == id));
            List<VacancyProposalDto> proposals = new List<VacancyProposalDto>();
            var vacancyPersons = _db.VacancyPersons.Where(x => x.VacancyId == id).ToList();
            foreach(var person in vacancyPersons)
            {
                VacancyProposalDto propsal = new VacancyProposalDto()
                {
                    Id = person.PersonId,
                    ProposalFirstname = _db.Persons.FirstOrDefault(x => x.Id == person.PersonId).Firstname,
                    ProposalLastname = _db.Persons.FirstOrDefault(x => x.Id == person.PersonId).Lastname
                };
                proposals.Add(propsal);

            }
            GetMyVacanciesDto data = new GetMyVacanciesDto()
            {
                Vacancy = vacancy,
                Proposal = proposals
            };
            return new ResponseModel<GetMyVacanciesDto>()
            {
                Data =data
            };
        }
        public async Task<IResponse<List<GetVacancyDto>>> GetList(int? categoryId, string? titleContains, string? location)
        {
            return new ResponseModel<List<GetVacancyDto>>()
            {
                
                Data =
                _mapper.Map<List<GetVacancyDto>>(_db.Vacancies.Where(x => x.IsFinished == false && x.Location.Contains(location??"")  && (x.CategoryId==categoryId || categoryId==null) && x.Title.Contains(titleContains??"")).ToList())
            };
        }
        public async Task<IResponse<List<GetVacancyDto>>> GetMyVacancies()
        {
            var userId = _db.Persons.FirstOrDefault(x => x.Id == _jwtPasswordService.GetUserId()).Id;
            return new ResponseModel<List<GetVacancyDto>>()
            {
                Data =
                _mapper.Map<List<GetVacancyDto>>(_db.Vacancies.Where(x =>
                x.CreatePersonId == userId
                && x.IsActive == true
                && x.IsDeleted == false).ToList())
            };
        }
        public async Task<IResponse<List<GetVacancyDto>>> GetMyOffers()
        {
            var userId = _db.Persons.FirstOrDefault(x => x.Id == _jwtPasswordService.GetUserId()).Id;

            return new ResponseModel<List<GetVacancyDto>>()
            {
                Data =
                _mapper.Map<List<GetVacancyDto>>(_db.Vacancies.Where(x =>
                x.VacancyPersons.Any(w => w.PersonId == userId)
                //&& x.IsActive == true
                && x.IsDeleted == false).ToList())
            };
        }
        public async Task<IResponse<bool>> Create(VacancyDto input, long userId)
        {
            VacancyPersonDto vp = new VacancyPersonDto();
            var vacancy = _mapper.Map<Vacancy>(input);
            vacancy.CreatePersonId = _db.Persons.FirstOrDefault(x => x.Id == _jwtPasswordService.GetUserId()).Id;
            var createPersonFirstname = _db.Persons.FirstOrDefault(x => x.Id == vacancy.CreatePersonId).Firstname;
            var createPersonLastname = _db.Persons.FirstOrDefault(x => x.Id == vacancy.CreatePersonId).Lastname;
            vacancy.CreatePersonName = createPersonFirstname + ' ' + createPersonLastname;

            _db.Add(vacancy);
            if (userId != 0)
            {
                vp.IsApproved = false;
                vp.PersonId = userId;
                vacancy.AddPerson(_mapper.Map<VacancyPerson>(vp));
            }
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

        public async Task<IResponse<bool>> SubmitProposal(long vacancyId)
        {
            var userId = _db.Persons.FirstOrDefault(x => x.Id == _jwtPasswordService.GetUserId()).Id;
            VacancyPersonDto vp = new VacancyPersonDto();
            vp.PersonId = userId;
            vp.VacancyId = vacancyId;
            vp.IsApproved = false;
            //_db.Add(vp);
            var vacancy = _db.Vacancies.FirstOrDefault(x => x.Id == vacancyId);
            vacancy.AddPerson(_mapper.Map<VacancyPerson>(vp));
            _db.Update(vacancy);
            _db.SaveChanges();
            return new ResponseModel<bool>() { Data = true };

        }
        public async Task<IResponse<bool>> Approve(long vacancyId)
        {
            var vacancyPerson = _db.VacancyPersons.FirstOrDefault(x => x.VacancyId == vacancyId);
            vacancyPerson.IsApproved = true;
            _db.Update(vacancyPerson);
            _db.SaveChanges();
            return new ResponseModel<bool>() { Data = true };
        }

        public async Task<IResponse<bool>> ApproveByOwner(long vacancyId, long personId)
        {
            var vacancyPerson = _db.VacancyPersons.FirstOrDefault(x => x.VacancyId == vacancyId && x.PersonId == personId);
            vacancyPerson.IsApproved = true;
            _db.Update(vacancyPerson);
            _db.SaveChanges();
            return new ResponseModel<bool>() { Data = true };

        }


        public async Task<IResponse<bool>> Finish(long vacancyId)
        {
            Vacancy vacancy = _db.Vacancies.FirstOrDefault(x => x.Id == vacancyId);
            vacancy.IsFinished = true;
            vacancy.IsDoing = false;
            vacancy.IsActive = false;
            _db.Update(vacancy);
            _db.SaveChanges();
            return new ResponseModel<bool>() { Data = true };
        }

    }

}