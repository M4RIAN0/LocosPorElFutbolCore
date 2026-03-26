using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class ProvinciaRepository : Repository<Provincia>, IProvinciaRepository
    {
        public ProvinciaRepository(LxfContext context) : base(context)
        {
        }
    }
}
