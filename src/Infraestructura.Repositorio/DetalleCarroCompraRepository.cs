using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class DetalleCarroCompraRepository : Repository<DetalleCarroCompra>, IDetalleCarroCompraRepository
    {
        public DetalleCarroCompraRepository(LxfContext context): base(context)
        {
            
        }
    }
}
