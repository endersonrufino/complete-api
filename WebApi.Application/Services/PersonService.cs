using AutoMapper;
using WebApi.Application.DTOs;
using WebApi.Application.DTOs.Validations;
using WebApi.Application.Services.Interfaces;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;

namespace WebApi.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
            {
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado!");
            }

            var result = new PersonDTOValidator().Validate(personDTO);

            if (!result.IsValid)
            {
                return ResultService.RequestError<PersonDTO>("Problema nos valores informados", result);
            }

            var person = _mapper.Map<Person>(personDTO);

            var data = await _personRepository.CreateAsync(person);

            return ResultService.Ok<PersonDTO>(_mapper.Map<Person, PersonDTO>(data));
        }
    }
}
