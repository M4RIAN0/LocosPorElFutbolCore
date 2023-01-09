using DominioBase;

namespace Infraestructura.RepositorioBase
{
    public interface IRepositorioOperaciones<T> where T : EntidadBase
    {
        void Agregar(T entidad);

        void Modificar(T entidad);

        void Eliminar(long id);

        void Save();
    }
}
