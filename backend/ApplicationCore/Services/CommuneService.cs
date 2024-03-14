
using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using AutoMapper;


namespace ApplicationCore.Services
{
    public class CommuneService : ICommuneService
    {
        ICommuneRepository _communeRepository;
        IMapper _mapper;
        public CommuneService(
            ICommuneRepository communeRepository,
            IMapper mapper
        )
        {
            _communeRepository = communeRepository;
            _mapper = mapper;
        }

        public async Task<List<CommuneGetDto>> GetByRegionAndCityCode(short cityCode, short regionCode)
        {
            var communes = await _communeRepository.GetByRegionAndCityCodeAsync(cityCode, regionCode);

            List<CommuneGetDto> result = communes.Select(e => _mapper.Map<CommuneGetDto>(e)).ToList();

            return result;
        }
        

    }
}
