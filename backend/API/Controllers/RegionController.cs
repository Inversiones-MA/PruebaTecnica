using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStorageApi.Controllers
{
    [ApiController]
    [Route("region")]
    public class RegionController : ControllerBase
    {

        private readonly ILogger<RegionController> _logger;
        private IRegionService _regionService { get; }


        public RegionController(ILogger<RegionController> logger, IRegionService regionService)
        {
            _logger = logger;
            _regionService = regionService;
        }


        [HttpGet("")]
        public async Task<ActionResult<List<RegionGetDto>>> GetAll()
        {
            try
            {
                var regions = await _regionService.GetAll();
                return Ok(regions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting persons: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }



    }
}
