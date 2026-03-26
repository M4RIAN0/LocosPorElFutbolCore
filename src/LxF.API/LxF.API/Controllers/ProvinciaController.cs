using IServicio;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaService _service;

        public ProvinciaController(IProvinciaService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetAllProvincias()
        {
            var result =_service.GetAll();
            return Ok(result);
        }

    }
}
