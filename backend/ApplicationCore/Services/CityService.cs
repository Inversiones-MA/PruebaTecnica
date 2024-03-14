
using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using AutoMapper;


namespace ApplicationCore.Services
{
    public class CityService : ICityService
    {
        ICityRepository _cityRepository;
        IMapper _mapper;
        public CityService(
            ICityRepository cityRepository,
            IMapper mapper
        )
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<List<CityGetDto>> GetByRegionCode(short regionCode)
        {
            var cities = await _cityRepository.GetByRegionCodeAsync(regionCode);

            List<CityGetDto> result = cities.Select(e => _mapper.Map<CityGetDto>(e)).ToList();

            return result;
        }
        

    }
}
