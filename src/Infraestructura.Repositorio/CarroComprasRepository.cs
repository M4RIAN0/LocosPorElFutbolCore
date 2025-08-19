using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class CarroComprasRepository: Repository<CarroCompras>, ICarroComprasRepository
    {
        public CarroComprasRepository(LxfContext context): base(context)
        {
        }
    }
}
