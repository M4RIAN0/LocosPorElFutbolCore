using IServicio;
using IServicio.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _service;
        private readonly IOrdenCompraService _ordenCompraService;

        public VentaController(IVentaService service, IOrdenCompraService ordenCompraService)
        {
            _service = service;
            _ordenCompraService = ordenCompraService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult PersistObjects([FromBody] TransactionObjectsDto request)
        {
            _service.PersistObjects(request);
            return Ok();
        }

        [HttpGet("{clienteId:int}/getComprobanteByCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetComprobanteByClienteId(int clienteId)
        {
            var result = _service.GetComprobantesByClienteId (clienteId);
            return Ok(result);
        }

        [HttpGet("{id:int}/getComprobanteById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetComprobanteById(int id)
        {
            var result = _service.GetComprobantebyId(id);
            return Ok(result);
        }

        [HttpGet("getLastOrden")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetLast()
        {
            var result = _ordenCompraService.GetLast();
            return Ok(result);
        }
    }
}
