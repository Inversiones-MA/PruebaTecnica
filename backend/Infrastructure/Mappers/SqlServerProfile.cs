using ApplicationCore.Entities;
using AutoMapper;
using Infrastructure.SqlServerContext;

namespace Infrastructure.Mappers
{
    public class SqlServerProfile:Profile
    {
        public SqlServerProfile() {

            CreateMap<Persona, Person>()
               .ForMember(dest => dest.Run, opt => opt.MapFrom(src => src.Run))
               .ForMember(dest => dest.RunBody, opt => opt.MapFrom(src => src.RunCuerpo))
               .ForMember(dest => dest.RunDigit, opt => opt.MapFrom(src => src.RunDigito))
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Nombres))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ApellidoPaterno))
               .ForMember(dest => dest.MotherLastName, opt => opt.MapFrom(src => src.ApellidoMaterno))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.GenderCode, opt => opt.MapFrom(src => src.SexoCodigo))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.FechaNacimiento))
               .ForMember(dest => dest.RegionCode, opt => opt.MapFrom(src => src.RegionCodigo))
               .ForMember(dest => dest.CityCode, opt => opt.MapFrom(src => src.CiudadCodigo))
               .ForMember(dest => dest.CommuneCode, opt => opt.MapFrom(src => src.ComunaCodigo))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Direccion))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Telefono))
               .ForMember(dest => dest.Observations, opt => opt.MapFrom(src => src.Observaciones))
               .ReverseMap();

            CreateMap<Person, Persona>()
                .ForMember(dest => dest.RunCuerpo, opt => opt.MapFrom(src => src.RunBody))
                .ForMember(dest => dest.RunDigito, opt => opt.MapFrom(src => src.RunDigit))
                .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Names))
                .ForMember(dest => dest.ApellidoPaterno, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.ApellidoMaterno, opt => opt.MapFrom(src => src.MotherLastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.SexoCodigo, opt => opt.MapFrom(src => src.GenderCode))
                .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.RegionCodigo, opt => opt.MapFrom(src => src.RegionCode))
                .ForMember(dest => dest.CiudadCodigo, opt => opt.MapFrom(src => src.CityCode))
                .ForMember(dest => dest.ComunaCodigo, opt => opt.MapFrom(src => src.CommuneCode))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.Observations))
                .ReverseMap();

            CreateMap<SqlServerContext.Region, ApplicationCore.Entities.Region>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NombreOficial))
                .ForMember(dest => dest.OficialName, opt => opt.MapFrom(src => src.NombreOficial))
                .ReverseMap();

            CreateMap<Ciudad, City>()
               .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Codigo))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.RegionCode, opt => opt.MapFrom(src => src.RegionCodigo))
               .ReverseMap();

            CreateMap<Comuna, Commune>()
               .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Codigo))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.RegionCode, opt => opt.MapFrom(src => src.RegionCodigo))
               .ForMember(dest => dest.CityCode, opt => opt.MapFrom(src => src.CiudadCodigo))
               .ReverseMap();
        }
    }
}
