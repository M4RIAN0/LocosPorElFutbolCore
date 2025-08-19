using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class DetalleCarroComprasRepository : Repository<DetalleCarroCompras>, IDetalleCarroComprasRepository
    {
        public DetalleCarroComprasRepository(LxfContext context): base(context)
        {
            
        }
    }
}
