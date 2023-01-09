using DominioBase;

namespace Infraestructura.RepositorioBase
{
    public interface IRepositorio<T> : IRepositorioConsulta<T>, IRepositorioOperaciones<T> where T : EntidadBase
    {
    }
}
