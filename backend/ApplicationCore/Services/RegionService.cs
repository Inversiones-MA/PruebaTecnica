
using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using AutoMapper;


namespace ApplicationCore.Services
{
    public class RegionService : IRegionService
    {
        IRegionRepository _regionRepository;
        IMapper _mapper;
        public RegionService(
            IRegionRepository regionRepository,
            IMapper mapper
        )
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public async Task<List<RegionGetDto>> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();

            List<RegionGetDto> result = regions.Select(e => _mapper.Map<RegionGetDto>(e)).ToList();

            return result;
        }
        

    }
}
