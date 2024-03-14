using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStorageApi.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService { get; }


        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] Person person)
        {
            try
            {
                Guid idNew = await _personService.Add(person);

                return Ok(idNew);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inserting game: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("")]
        public async Task<ActionResult<List<Person>>> GetAllGenres()
        {
            try
            {
                var genres = await _personService.GetAll();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting persons: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }



    }
}
