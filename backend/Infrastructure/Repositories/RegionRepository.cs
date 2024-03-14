
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Infrastructure.SqlServerContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Region = Infrastructure.SqlServerContext.Region;

namespace Infrastructure.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        protected readonly PruebaTecnicaContext DbContext;
        protected readonly DbSet<Region> DbSet;
        private readonly IMapper _mapper;

        public RegionRepository(PruebaTecnicaContext context, IMapper mapper)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = DbContext.Set<Region>();
            _mapper = mapper;
        }

        public async Task<List<ApplicationCore.Entities.Region>> GetAllAsync()
        {
            var regions = await DbSet.ToListAsync();
            return _mapper.Map<List<ApplicationCore.Entities.Region>>(regions);
        }

       

    }

}
