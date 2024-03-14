using ApplicationCore.DTO;
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
        public async Task<ActionResult<Guid>> Create([FromBody] PersonPostDto person)
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
        public async Task<ActionResult<List<PersonGetDto>>> GetAll()
        {
            try
            {
                var persons = await _personService.GetAll();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting persons: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }



    }
}
