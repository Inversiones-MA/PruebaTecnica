using ApplicationCore.DTO;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Services
{
    public interface ICityService
    {

        Task<List<CityGetDto>> GetByRegionCode(short regionCode);

    }
}
