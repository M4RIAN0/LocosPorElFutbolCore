using Dominio.Entidades;
using Dominio;
using Infraestructura.Repositorio.repository;
using Dominio.Repositorio;

namespace Infraestructura.Repositorio
{
    public class TarjetaRepository : Repository<Tarjeta>, ITarjetaRepository
    {
        public TarjetaRepository(LxfContext context) : base(context)
        {
        }
    }
}
