using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
    }
}
