using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class EnvioRepository : Repository<Envio>, IEnvioRepository
    {
        public EnvioRepository(LxfContext context) : base(context)
        {
        }
    }
}
