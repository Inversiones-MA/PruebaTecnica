using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStorageApi.Controllers
{
    [ApiController]
    [Route("commune")]
    public class CommuneController : ControllerBase
    {

        private readonly ILogger<CommuneController> _logger;
        private ICommuneService _communeService { get; }


        public CommuneController(ILogger<CommuneController> logger, ICommuneService communeService)
        {
            _logger = logger;
            _communeService = communeService;
        }


        [HttpGet("")]
        public async Task<ActionResult<List<CommuneGetDto>>> GetByRegionAndCityCode(short regionCode, short cityCode)
        {
            try
            {
                var communes = await _communeService.GetByRegionAndCityCode(cityCode, regionCode);
                return Ok(communes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting persons: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }



    }
}
