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
        private readonly ICarroComprasService _service;

        public CarroController(ICarroComprasService service)
        {
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

        [HttpPut("{id:int}/AddItem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult AddItemCart(int id)
        {
            _service.AddItem(id);
            return Ok();
        }

        [HttpPut("{id:int}/SubstractItem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult SubtractItemCart(int id)
        {
            _service.SubtractItem(id);
            return Ok();
        }

        [HttpDelete("{id:int}/delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult RemoveCart(int id)
        {
            _service.Remove(id);
            return Ok();
        }

        [HttpDelete("{id:int}/deleteItem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult RemoveItemeCart(int id)
        {
            _service.Removeitem(id);
            return Ok();
        }

    }
}
