﻿using AutoMapper;
using Lennt.Dto;
using Lennt.Dto.Person;
using Lennt.Model;
using Lennt.Model.Entities;
using Lennt.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Lennt.Services.Service.Persons
{
    public class PersonAppService : IPersonAppSevice
    {
        private readonly LenntDbContext _db;
        private readonly IMapper _mapper;
        private readonly IJwtPasswordInterface _jwtPasswordService;
        public PersonAppService(
            LenntDbContext db,
            IMapper mapper,
            IJwtPasswordInterface jwtPasswordInterface)
        {
            _db = db;
            _mapper = mapper;
            _jwtPasswordService = jwtPasswordInterface;
        }

        public async Task<IResponse<PersonDto>> Get()
        {
            return new ResponseModel<PersonDto>()
            {
                Data =
                _mapper.Map<PersonDto>(_db.Persons.FirstOrDefault(x => x.Id == _jwtPasswordService.GetUserId()))
            };
        }


        public async Task<IResponse<string>> Login(LoginDto input)
        {
            var person = _db.Persons.FirstOrDefault(x => x.Username == input.UserName);
            if (person == null)
            {
                return new ResponseModel<string>() { Error = "Invalid userName or password", Data = null };
            }
            string token = "";
            if (_jwtPasswordService.ValidatePassword(input.Password, person.Password))
            {
                token = _jwtPasswordService.GenerateJwtToken(person.Username, person.Id);
            }
            if (token == "")
            {
                return new ResponseModel<string>() { Error = "Invalid userName or password", Data = null };
            }
            return new ResponseModel<string>() { Data = token };
        }

        public async Task<IResponse<bool>> Register(PersonDto input)
        {
            var person = _mapper.Map<Person>(input);
            person.Password = _jwtPasswordService.HashPassword(person.Password);
            _db.Add(person);
            _db.SaveChanges();
            return new ResponseModel<bool>() { Data = true };
        }
    }
}
