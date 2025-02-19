using Infraestructura;
using IServicio.Categoria;
using IServicio.Categoria.Dto;
using IServicio.PersonaCliente;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly LxfContext _db;
        private readonly ICategoriaServicio _service;

        public CategoriaController(LxfContext db, ICategoriaServicio service)
        {
            _db = db;
            _service = service;
        }
        
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetCategorias()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateCategoria([FromBody] CategoriaDto request)
        {
            _service.Add(request);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult EditCategoria([FromBody] CategoriaPutDto request)
        {
            _service.Update(request);
            return Ok();
        }

        [HttpPut("{id:int}/delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult SoftDeleteCategoria(int id)
        {
            _service.SoftDelete(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetCategoriaById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByFilter")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetCategoriasByFilter(string word)
        {
            var result = _service.GetByFilter(word);
            return Ok(result);
        }


    }
}
