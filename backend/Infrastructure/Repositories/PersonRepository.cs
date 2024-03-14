
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Infrastructure.SqlServerContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        protected readonly PruebaTecnicaContext DbContext;
        protected readonly DbSet<Persona> DbSet;
        private readonly IMapper _mapper;

        public PersonRepository(PruebaTecnicaContext context, IMapper mapper)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = DbContext.Set<Persona>();
            _mapper = mapper;
        }

        //public async Task<Guid> AddPerson(Person person)
        //{
        //    try
        //    {
        //        Persona persona = _mapper.Map<Persona>(person);
        //        await DbSet.AddAsync(persona);
        //        await DbContext.SaveChangesAsync();
        //        return persona.Id;
        //    }
        //    catch(Exception ex) { 
        //        return Guid.Empty;
        //    }
           
        //}

        public async Task<Guid> AddPerson(Person person)
        {
            try
            {
                // Mapea la entidad Person a la entidad Persona
                Persona persona = _mapper.Map<Persona>(person);

                // Prepara la consulta SQL para la inserción
                string insertQuery = @"
                INSERT INTO [Persona] ([Id], [RunCuerpo], [RunDigito], [Nombres], 
                [ApellidoPaterno], [ApellidoMaterno], [Email], [SexoCodigo], [FechaNacimiento], 
                [RegionCodigo], [CiudadCodigo], [ComunaCodigo], [Direccion], [Telefono], [Observaciones])
                VALUES (@Id, @RunCuerpo, @RunDigito, @Nombres, @ApellidoPaterno, 
                @ApellidoMaterno, @Email, @SexoCodigo, @FechaNacimiento, @RegionCodigo, @CiudadCodigo, 
                @ComunaCodigo, @Direccion, @Telefono, @Observaciones);";

                // Parámetros para la consulta SQL
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Id", persona.Id),
                    new SqlParameter("@RunCuerpo", persona.RunCuerpo),
                    new SqlParameter("@RunDigito", persona.RunDigito),
                    new SqlParameter("@Nombres", persona.Nombres),
                    new SqlParameter("@ApellidoPaterno", persona.ApellidoPaterno),
                    new SqlParameter("@ApellidoMaterno", persona.ApellidoMaterno),
                    new SqlParameter("@Email", persona.Email),
                    new SqlParameter("@SexoCodigo", persona.SexoCodigo),
                    new SqlParameter("@FechaNacimiento", persona.FechaNacimiento),
                    new SqlParameter("@RegionCodigo", persona.RegionCodigo),
                    new SqlParameter("@CiudadCodigo", persona.CiudadCodigo),
                    new SqlParameter("@ComunaCodigo", persona.ComunaCodigo ?? (object)DBNull.Value),
                    new SqlParameter("@Direccion", persona.Direccion),
                    new SqlParameter("@Telefono", persona.Telefono ?? (object)DBNull.Value),
                    new SqlParameter("@Observaciones", persona.Observaciones)
                };

                // Ejecuta la consulta SQL para la inserción
                await DbContext.Database.ExecuteSqlRawAsync(insertQuery, parameters);

                // Devuelve el ID de la persona insertada
                return persona.Id;
            }
            catch (Exception ex)
            {
                // Manejo de errores aquí...
                return Guid.Empty;
            }
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            var personas = await DbSet.ToListAsync();
            return _mapper.Map<List<Person>>(personas);
        }

        public async Task UpdatePerson(Person person)
        {
            Persona persona = _mapper.Map<Persona>(person);
            DbSet.Update(persona);

            await DbContext.SaveChangesAsync();

        }

        public void Remove(Person person)
        {
            Persona persona = _mapper.Map<Persona>(person);
            DbSet.Remove(persona);
            DbContext.SaveChanges();
        }

    }

}
