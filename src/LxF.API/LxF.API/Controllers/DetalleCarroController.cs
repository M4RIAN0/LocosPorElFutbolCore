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
        private readonly IDetalleCarroCompraService _detalleCarroComprasService;

        public DetalleCarroController(IDetalleCarroCompraService detalleCarroComprasService)
        {
            _detalleCarroComprasService = detalleCarroComprasService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateDetailsCart([FromBody] DetalleCarroCompraDto request)
        {
            _detalleCarroComprasService.Add(request);
            return Ok();
        }
    }
}
