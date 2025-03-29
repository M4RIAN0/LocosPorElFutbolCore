using Dominio;
using Dominio.Entidades;
using Infraestructura.Repositorio.repository;

namespace Infraestructura.Repositorio
{
    public class TalleRepository : Repository<Talle>, ITalleRepository
    {
        public TalleRepository(LxfContext context) : base(context)
        {
        }
    }

}

