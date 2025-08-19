using Infraestructura;
using IServicio;
using IServicio.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly LxfContext _db;
        private readonly ICarroComprasService _service;

        public CarroController(LxfContext db, ICarroComprasService service)
        {
            _db = db;
            _service = service;
        }

        [HttpGet ("{userId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetCartByUserId(string userId)
        {
            var result = _service.GetByUserId(userId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateCart([FromBody] CarroComprasDto request)
        {
            _service.Add(request);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult EditCart([FromBody] CarroComprasPutDto request)
        {
            _service.Update(request);
            return Ok();
        }

        [HttpPut("{id:int}/delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult SoftDeleteCart(int id)
        {
            _service.SoftDelete(id);
            return Ok();
        }

    }
}
