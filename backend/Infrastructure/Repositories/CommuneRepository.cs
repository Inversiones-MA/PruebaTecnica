
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Infrastructure.SqlServerContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CommuneRepository : ICommuneRepository
    {
        protected readonly PruebaTecnicaContext DbContext;
        protected readonly DbSet<Comuna> DbSet;
        private readonly IMapper _mapper;

        public CommuneRepository(PruebaTecnicaContext context, IMapper mapper)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = DbContext.Set<Comuna>();
            _mapper = mapper;
        }

        public async Task<List<Commune>> GetByRegionAndCityCodeAsync(short cityCode, short regionCode)
        {
            var communes = await DbSet.Where(c => c.CiudadCodigo == regionCode && c.RegionCodigo == regionCode).ToListAsync();
            return _mapper.Map<List<Commune>>(communes);
        }

       

    }

}
