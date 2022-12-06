using Finfast.Desafio.Domain.Entities;
using Finfast.Desafio.Domain.Helpers;
using Finfast.Desafio.Domain.Models;
using Finfast.Desafio.Infrastucture.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Finfast.Desafio.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IRepository<Persona> _personaRepository;

        public PersonaController(IRepository<Persona> personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        [Route("personas")]
        public virtual IActionResult GetPersonas()
        {
            var personas = _personaRepository.Get(null).ToList().ToModels();

            return Ok(personas);
        }

        [HttpGet]
        [Route("personas/{id}")]
        public virtual IActionResult GetPersona(
            [FromRoute] System.Guid id)
        {
            var cuidadano = _personaRepository.Get(x => x.Id == id, "Sexo").FirstOrDefault();

            if (cuidadano == null)
            {
                return NotFound("Persona no existe");
            }

            return Ok(cuidadano.ToModel());
        }

        [HttpPost]
        [Route("personas")]
        public virtual IActionResult CreatePersona(
            [FromBody] PersonaRequest request)
        {
            var isRutValid = RutValidator.ValidaRut(request.RunCuerpo.ToString() + "-" + request.RunDigito);

            if (!isRutValid)
            {
                return BadRequest("Run invalido");
            }

            Persona persona = request.ToEntity();

            var personaResponse = _personaRepository.Create(persona);

            return Created(Request.GetDisplayUrl(), personaResponse.ToModel());
        }

        [HttpPut]
        [Route("personas/{id}")]
        public virtual IActionResult UpdatePersona(
            [FromBody] PersonaRequest request,
            [FromRoute] System.Guid id)
        {
            var isRutValid = RutValidator.ValidaRut(request.RunCuerpo.ToString() + "-" + request.RunDigito);

            if (!isRutValid)
            {
                return BadRequest("Run invalido");
            }

            var persona = _personaRepository.Get(x => x.Id == id).FirstOrDefault();

            if (persona == null)
            {
                return NotFound("La persona no existe");
            }

            request.ToUpdate(persona);

            persona = _personaRepository.Update(persona);

            return Ok(persona);
        }

        [HttpDelete]
        [Route("personas/{id}")]
        public virtual IActionResult DeletePersona(
            [FromRoute] System.Guid id)
        {
            var persona = _personaRepository.Get(x => x.Id == id).FirstOrDefault();

            if (persona == null)
            {
                return NotFound("La persona no existe");
            }

            _personaRepository.Remove(persona);

            return NoContent();
        }
    }
}
