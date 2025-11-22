using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class OrdenCompraRepository(LxfContext context) : Repository<OrdenCompra>(context), IOrdenCompraRepository
    {
    }
}
