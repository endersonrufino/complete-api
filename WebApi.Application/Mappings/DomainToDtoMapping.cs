using AutoMapper;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
        }
    }
}
