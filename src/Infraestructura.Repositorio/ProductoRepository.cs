using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(LxfContext context) : base(context)
        {
        }
    }
}
