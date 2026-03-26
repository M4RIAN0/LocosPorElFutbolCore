using IServicio;
using IServicio.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EnvioController : ControllerBase
    {
        private readonly IEnvioService _service;

        public EnvioController(IEnvioService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetEnvioById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByFilter")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetEnviosByFilter(string persona)
        {
            var result = _service.GetByFilter(persona);
            return Ok(result);
        }

    }
}
