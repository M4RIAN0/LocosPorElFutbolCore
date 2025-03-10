using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class ComprobanteRepository : Repository<Comprobante>, IComprobanteRepository
    {
        public ComprobanteRepository(LxfContext context) : base(context)
        {
        }
    }
}
