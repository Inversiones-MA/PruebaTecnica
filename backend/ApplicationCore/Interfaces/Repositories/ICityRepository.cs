using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetByRegionCodeAsync(short regionCode);
    }
}
