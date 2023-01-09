using Dominio.Repositorio.PersonaCliente;

namespace Infraestructura.Repositorio.PersonaCliente
{
    public class PersonaClienteRepositorio : Repositorio<Dominio.Entidades.Persona_Cliente>, IPersonaClienteRepositorio
    {
        public PersonaClienteRepositorio(LxfContext context) : base(context)
        {
        }
    }

}
