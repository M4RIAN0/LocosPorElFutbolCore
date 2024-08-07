using Infraestructura;
using IServicio.PersonaCliente;
using Microsoft.AspNetCore.Mvc;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly LxfContext _db;
        private readonly IPersonaClienteServicio _personaClienteServicio;

        public PersonaController(LxfContext db, IPersonaClienteServicio personaClienteServicio)
        {
            _db = db;
            _personaClienteServicio = personaClienteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonas()
        {
            return Ok(await _personaClienteServicio.GetAll());
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetPersonaById(long? id)
        {
            return Ok(await _personaClienteServicio.GetById(id));
        }
    }
}
