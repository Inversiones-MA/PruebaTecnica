using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStorageApi.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : ControllerBase
    {

        private readonly ILogger<CityController> _logger;
        private ICityService _cityService { get; }


        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }


        [HttpGet("")]
        public async Task<ActionResult<List<CityGetDto>>> GetByRegionCode(short regionCode)
        {
            try
            {
                var cities = await _cityService.GetByRegionCode(regionCode);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting persons: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }



    }
}
