using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class DetalleOrdenCompraRepository(LxfContext context) : Repository<DetalleOrdenCompra>(context), IDetalleOrdenCompraRepository
    {
    }
}
