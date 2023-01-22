using AutoMapper;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
        }
    }
}
