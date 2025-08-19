using Infraestructura;
using IServicio;
using IServicio.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCarroController : ControllerBase
    {
        private readonly LxfContext _db;
        private readonly IDetalleCarroComprasService _detalleCarroComprasService;
        private readonly ICarroComprasService _carroComprasService;

        public DetalleCarroController(IDetalleCarroComprasService detalleCarroComprasService, ICarroComprasService carroComprasService)
        {
            _detalleCarroComprasService = detalleCarroComprasService;
            _carroComprasService = carroComprasService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateDetailsCart([FromBody] DetalleCarroComprasDto request)
        {
            request.CarroComprasId = _carroComprasService.GetLast().ID;
            _detalleCarroComprasService.Add(request);
            return Ok();
        }


        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult EditDetailsCart([FromBody] DetalleCarroComprasPutDto request)
        {
            _detalleCarroComprasService.Update(request);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetProductoById(int id)
        {
            var result = _detalleCarroComprasService.GetById(id);
            return Ok(result);
        }
    }
}
