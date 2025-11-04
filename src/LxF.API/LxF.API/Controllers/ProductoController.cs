using Infraestructura;
using IServicio;
using IServicio.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly LxfContext _db;
        private readonly IProductoService _service;

        public ProductoController(LxfContext db, IProductoService service)
        {
            _db = db;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetProductos()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreatetProducto([FromBody] ProductoDto request)
        {
            _service.Add(request);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult EditProducto([FromBody] ProductoPutDto request)
        {
            _service.Update(request);
            return Ok();
        }

        [HttpPut("{id:int}/delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult SoftDeleteProducto(int id)
        {
            _service.SoftDelete(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetProductoById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByFilter")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetProductosByFilter(string word)
        {
            var result = _service.GetByFilter(word);
            return Ok(result);
        }
    }
}
