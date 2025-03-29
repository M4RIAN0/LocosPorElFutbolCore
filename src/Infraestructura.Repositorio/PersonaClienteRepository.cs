using Dominio;
using Dominio.Entidades;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class PersonaClienteRepository : Repository<PersonaCliente>, IPersonaClienteRepository
    {
        public PersonaClienteRepository(LxfContext context) : base(context)
        {
        }
    }

}
