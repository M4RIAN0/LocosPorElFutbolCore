using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class DetalleComprobanteRepository : Repository<DetalleComprobante>, IDetalleComprobanteRepository
    {
        public DetalleComprobanteRepository(LxfContext context) : base(context)
        {
        }
    }
}
