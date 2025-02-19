using Infraestructura;
using IServicio.Marca;
using IServicio.Marca.Dto;
using IServicio.PersonaCliente;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly LxfContext _db;
        private readonly IMarcaServicio _service;

        public MarcaController(LxfContext db, IMarcaServicio service)
        {
            _db = db;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetMarca()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateMarca([FromBody] MarcaDto request)
        {
            _service.Add(request);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult EditMarca([FromBody] MarcaPutDto request)
        {
            _service.Update(request);
            return Ok();
        }

        [HttpPut("{id:int}/delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult SoftDeleteMarca(int id)
        {
            _service.SoftDelete(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetMarcaById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpGet("getByFilter")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetMarcaByFilter([FromQuery] string word)
        {
            var result = _service.GetByFilter(word);
            return Ok(result);
        }
    }
}
