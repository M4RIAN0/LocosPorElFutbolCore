using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        public FacturaRepository(LxfContext context) : base(context)
        {
        }
    }
}
