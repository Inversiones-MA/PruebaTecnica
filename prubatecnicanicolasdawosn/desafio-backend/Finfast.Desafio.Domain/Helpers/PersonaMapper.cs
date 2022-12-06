using Finfast.Desafio.Domain.Entities;
using Finfast.Desafio.Domain.Models;

namespace Finfast.Desafio.Domain.Helpers
{
    public static class PersonaMapper
    {
        public static Persona ToEntity(this PersonaRequest personaRequest)
        {
            Persona entity = new();
            if (personaRequest != null)
            {
                entity.RunCuerpo = personaRequest.RunCuerpo;
                entity.RunDigito = personaRequest.RunDigito;
                entity.Nombres = personaRequest.Nombres;
                entity.ApellidoMaterno = personaRequest.ApellidoMaterno;
                entity.ApellidoPaterno = personaRequest.ApellidoPaterno;
                entity.Email = personaRequest.Email;
                entity.SexoCodigo = personaRequest.SexoCodigo;
                entity.FechaNacimiento = personaRequest.FechaNacimiento;
                entity.RegionCodigo = personaRequest.RegionCodigo;
                entity.ComunaCodigo = personaRequest.ComunaCodigo;
                entity.CiudadCodigo = personaRequest.CiudadCodigo;
                entity.Direccion = personaRequest.Direccion;
                entity.Telefono = personaRequest.Telefono;
                entity.Observaciones = personaRequest.Observaciones;
            }

            return entity;
        }

        public static IList<PersonaModel> ToModels(this ICollection<Persona> entities)
        {
            List<PersonaModel> models = new();
            if (entities != null && entities.Any())
            {
                foreach (var item in entities)
                {
                    models.Add(item.ToModel());
                }
            }

            return models;
        }

        public static PersonaModel ToModel(this Persona entity)
        {
            PersonaModel model = new();
            if (entity != null)
            {
                model.Id = entity.Id;
                model.Run = entity.Run;
                model.RunCuerpo = entity.RunCuerpo;
                model.RunDigito = entity.RunDigito;
                model.Nombre = entity.Nombre;
                model.Nombres = entity.Nombres;
                model.ApellidoMaterno = entity.ApellidoMaterno;
                model.ApellidoPaterno = entity.ApellidoPaterno;
                model.Email = entity.Email;
                model.SexoCodigo = entity.SexoCodigo;
                model.FechaNacimiento = entity.FechaNacimiento;
                model.RegionCodigo = entity.RegionCodigo;
                model.CiudadCodigo = entity.CiudadCodigo;
                model.ComunaCodigo = entity.ComunaCodigo;
                model.Direccion= entity.Direccion;
                model.Telefono = entity.Telefono;
                model.Observaciones = entity.Observaciones;
            }

            return model;
        }

        public static Persona ToUpdate(this PersonaRequest personaRequest, Persona entity)
        {
            if (personaRequest != null && entity != null)
            {
                entity.RunCuerpo = personaRequest.RunCuerpo;
                entity.RunDigito = personaRequest.RunDigito;
                entity.Nombres = personaRequest.Nombres;
                entity.ApellidoMaterno = personaRequest.ApellidoMaterno;
                entity.ApellidoPaterno = personaRequest.ApellidoPaterno;
                entity.Email = personaRequest.Email;
                entity.SexoCodigo = personaRequest.SexoCodigo;
                entity.FechaNacimiento = personaRequest.FechaNacimiento;
                entity.RegionCodigo = personaRequest.RegionCodigo;
                entity.ComunaCodigo = personaRequest.ComunaCodigo;
                entity.CiudadCodigo = personaRequest.CiudadCodigo;
                entity.Direccion = personaRequest.Direccion;
                entity.Telefono = personaRequest.Telefono;
                entity.Observaciones = personaRequest.Observaciones;
            }

            return entity;
        }
    }
}
