using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class MovimientoRepository : Repository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(LxfContext context) : base(context)
        {
        }
    }
}
