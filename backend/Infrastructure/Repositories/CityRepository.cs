
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Infrastructure.SqlServerContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        protected readonly PruebaTecnicaContext DbContext;
        protected readonly DbSet<Ciudad> DbSet;
        private readonly IMapper _mapper;

        public CityRepository(PruebaTecnicaContext context, IMapper mapper)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = DbContext.Set<Ciudad>();
            _mapper = mapper;
        }

        public async Task<List<City>> GetByRegionCodeAsync(short regionCode)
        {
            var cities = await DbSet.Where(c => c.RegionCodigo == regionCode).ToListAsync();
            return _mapper.Map<List<City>>(cities);
        }

       

    }

}
