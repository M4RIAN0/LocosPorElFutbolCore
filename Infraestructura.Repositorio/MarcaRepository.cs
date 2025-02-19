using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(LxfContext context) : base(context)
        {
        }
    }
}
