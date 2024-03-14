using ApplicationCore.DTO;
using ApplicationCore.Entities;
using AutoMapper;
using Infrastructure.SqlServerContext;

namespace Infrastructure.Mappers
{
    public class ApplicationProfile:Profile
    {
        public ApplicationProfile() {

            CreateMap<PersonPostDto, Person>();

            CreateMap<Person, PersonGetDto>();

            CreateMap<PersonPutDto, Person>();

            CreateMap<Region, RegionGetDto>();

            CreateMap<City, CityGetDto>();

            CreateMap<Commune, CommuneGetDto>();
        }
    }
}
