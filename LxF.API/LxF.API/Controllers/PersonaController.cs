using Infraestructura;
using IServicio;
using IServicio.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly LxfContext _db;
        private readonly IPersonaClienteService _service;

        public PersonaController(LxfContext db, IPersonaClienteService servicio)
        {
            _db = db;
            _service = servicio;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetAllPersonas()
        {
            var result = _service.GetAll();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreatePersona([FromBody] PersonaClienteDto request)
        {
            _service.Add(request);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult EditPersona([FromBody] PersonaClientePutDto request)
        {
            _service.Update(request);
            return Ok();
        }

        [HttpPut("{id:int}/delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult SoftDeletePersona(int id)
        {
            _service.SoftDelete(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetPersonaById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByFilter")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetPersonaByFilter(string word)
        {
            var result = _service.GetByFilter(word);
            return Ok(result);
        }
    }
}
