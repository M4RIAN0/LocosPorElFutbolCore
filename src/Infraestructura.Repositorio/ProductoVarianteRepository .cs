using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class ProductoVarianteRepository : Repository<ProductoVariante>, IProductoVarianteRepository
    {
        public ProductoVarianteRepository(LxfContext context) : base(context)
        {
        }
    }
}
