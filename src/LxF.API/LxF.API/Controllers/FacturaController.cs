using Infraestructura;
using IServicio;
using IServicio.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly LxfContext _db;
        private readonly IFacturaService _service;

        public FacturaController(LxfContext db, IFacturaService service)
        {
            _db = db;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetFacturas()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetFacturaById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }
    }
}
