using ApplicationCore.DTO;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Services
{
    public interface ICommuneService
    {

        Task<List<CommuneGetDto>> GetByRegionAndCityCode(short cityCode, short regionCode);

    }
}
