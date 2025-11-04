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
        private readonly ICarroCompraService _service;

        public CarroController(LxfContext db, ICarroCompraService service)
        {
            _db = db;
            _service = service;
        }

        [HttpGet ("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetCartByUserId(string userId)
        {
            var result = _service.GetByUserId(userId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateCart([FromBody] CarroCompraDto request)
        {
            _service.Add(request);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult EditCart([FromBody] CarroCompraPutDto request)
        {
            _service.Update(request);
            return Ok();
        }

        [HttpDelete("{id:int}/delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult RemoveItemeCart(int id)
        {
            _service.Removeitem(id);
            return Ok();
        }

    }
}
