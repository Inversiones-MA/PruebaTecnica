
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Infrastructure.SqlServerContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        protected readonly PruebaTecnicaContext DbContext;
        protected readonly DbSet<Persona> DbSet;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonRepository> _logger;

        public PersonRepository(PruebaTecnicaContext context, IMapper mapper, ILogger<PersonRepository> logger)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = DbContext.Set<Persona>();
            _mapper = mapper;
            _logger = logger;
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
                Persona persona = _mapper.Map<Persona>(person);

                string insertQuery = @"
                INSERT INTO [Persona] ([Id], [RunCuerpo], [RunDigito], [Nombres], 
                [ApellidoPaterno], [ApellidoMaterno], [Email], [SexoCodigo], [FechaNacimiento], 
                [RegionCodigo], [CiudadCodigo], [ComunaCodigo], [Direccion], [Telefono], [Observaciones])
                VALUES (@Id, @RunCuerpo, @RunDigito, @Nombres, @ApellidoPaterno, 
                @ApellidoMaterno, @Email, @SexoCodigo, @FechaNacimiento, @RegionCodigo, @CiudadCodigo, 
                @ComunaCodigo, @Direccion, @Telefono, @Observaciones);";

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
                    new SqlParameter("@RegionCodigo", persona.RegionCodigo ?? (object)DBNull.Value),
                    new SqlParameter("@CiudadCodigo", persona.CiudadCodigo ?? (object)DBNull.Value),
                    new SqlParameter("@ComunaCodigo", persona.ComunaCodigo ?? (object)DBNull.Value),
                    new SqlParameter("@Direccion", persona.Direccion),
                    new SqlParameter("@Telefono", persona.Telefono ?? (object)DBNull.Value),
                    new SqlParameter("@Observaciones", persona.Observaciones)
                };

                await DbContext.Database.ExecuteSqlRawAsync(insertQuery, parameters);

                return persona.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating person: {ex.Message}");
                return Guid.Empty;
            }
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            var personas = await DbSet.ToListAsync();
            return _mapper.Map<List<Person>>(personas);
        }

        //public async Task UpdatePerson(Person person)
        //{
        //    Persona persona = _mapper.Map<Persona>(person);
        //    DbSet.Update(persona);

        //    await DbContext.SaveChangesAsync();

        //}

        public async Task UpdatePerson(Person person)
        {
            try
            {
                Persona persona = _mapper.Map<Persona>(person);

                string updateQuery = @"
                    UPDATE [Persona] SET
                    [RunCuerpo] = @RunCuerpo,
                    [RunDigito] = @RunDigito,
                    [Nombres] = @Nombres,
                    [ApellidoPaterno] = @ApellidoPaterno,
                    [ApellidoMaterno] = @ApellidoMaterno,
                    [Email] = @Email,
                    [SexoCodigo] = @SexoCodigo,
                    [FechaNacimiento] = @FechaNacimiento,
                    [RegionCodigo] = @RegionCodigo,
                    [CiudadCodigo] = @CiudadCodigo,
                    [ComunaCodigo] = @ComunaCodigo,
                    [Direccion] = @Direccion,
                    [Telefono] = @Telefono,
                    [Observaciones] = @Observaciones
                    WHERE [Id] = @Id;";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Id", persona.Id),
                    new SqlParameter("@RunCuerpo", persona.RunCuerpo),
                    new SqlParameter("@RunDigito", persona.RunDigito),
                    new SqlParameter("@Nombres", persona.Nombres),
                    new SqlParameter("@ApellidoPaterno", persona.ApellidoPaterno),
                    new SqlParameter("@ApellidoMaterno", persona.ApellidoMaterno ??(object) DBNull.Value),
                    new SqlParameter("@Email", persona.Email ?? (object)DBNull.Value),
                    new SqlParameter("@SexoCodigo", persona.SexoCodigo),
                    new SqlParameter("@FechaNacimiento", persona.FechaNacimiento),
                    new SqlParameter("@RegionCodigo", persona.RegionCodigo ??(object) DBNull.Value),
                    new SqlParameter("@CiudadCodigo", persona.CiudadCodigo ?? (object)DBNull.Value),
                    new SqlParameter("@ComunaCodigo", persona.ComunaCodigo ?? (object)DBNull.Value),
                    new SqlParameter("@Direccion", persona.Direccion ?? (object)DBNull.Value),
                    new SqlParameter("@Telefono", persona.Telefono ?? (object)DBNull.Value),
                    new SqlParameter("@Observaciones", persona.Observaciones ?? (object)DBNull.Value)
                };

                await DbContext.Database.ExecuteSqlRawAsync(updateQuery, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating person: {ex.Message}");
            }
        }


        public void Remove(Person person)
        {
            Persona persona = _mapper.Map<Persona>(person);
            DbSet.Remove(persona);
            DbContext.SaveChanges();
        }

    }

}
