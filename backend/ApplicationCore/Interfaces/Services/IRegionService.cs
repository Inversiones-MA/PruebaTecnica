using ApplicationCore.DTO;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Services
{
    public interface IRegionService
    {

        Task<List<RegionGetDto>> GetAll();

    }
}
