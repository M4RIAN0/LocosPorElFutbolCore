using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class CarroCompraRepository(LxfContext context) : Repository<CarroCompra>(context), ICarroCompraRepository
    {
    }
}
