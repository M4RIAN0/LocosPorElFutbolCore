using Dominio.Entidades.MetaData;
using Infraestructura;
using IServicio.PersonaCliente;
using IServicio.PersonaCliente.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<PersonaClienteDto>>> GetAllPersonas()
        {
            return Ok (await _personaClienteServicio.GetAll());  
        }
    }
}
