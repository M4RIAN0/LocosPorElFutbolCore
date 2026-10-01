using Dominio.Repositorio.Dtos;
using Infraestructura;
using IServicio;
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

        [HttpGet("GetByIdProductoVariante/{productoVarianteId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetProductoByIdProductoVariante(int productoVarianteId)
        {
            var result = _service.GetByIdProductoVariante(productoVarianteId);
            return Ok(result);
        }

        [HttpGet("GetInStockProductos")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetInStockProductos()
        {
            var result = _service.GetInStockProductos();
            return Ok(result);
        }

        [HttpGet("GetSimilProductos/{id:int}/{categoriaId:int}/{marcaId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetSimilProductos(int id, int categoriaId, int marcaId)
        {
            var result = _service.GetSimilProductos(id, categoriaId, marcaId);
            return Ok(result);
        }

        [HttpGet("GetInterestingProductos/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetInterestingProductos(int id)
        {
            var result = _service.GetInterestingProductos(id);
            return Ok(result);
        }

        [HttpGet("GetByFilterGenderProductos/{word}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetByFilterGenderProductos(string word)
        {
            var result = _service.GetByFilterGenderProductos(word);
            return Ok(result);
        }

        [HttpGet("GetLastProducto")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetLastProducto()
        {
            var result = _service.GetLast();
            return Ok(result);
        }

    }
}
