using ApplicationCore.Entities;
using Infrastructure.SqlServerContext;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ICommuneRepository
    {
        Task<List<Commune>> GetByRegionAndCityCodeAsync(short cityCode, short regionCode);
    }
}
