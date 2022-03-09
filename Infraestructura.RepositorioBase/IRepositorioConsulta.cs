using DominioBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infraestructura.RepositorioBase
{
    public interface IRepositorioConsulta<T> where T : EntidadBase
    {
        IEnumerable<T> ObtenerTodo();
        IEnumerable<T> ObtenerTodo(params Expression<Func<T, Object>>[] includeProperties);
        IEnumerable<T> ObtenerTodo(string includeProperties);

        T ObtenerPorId(long? Id);
        T ObtenerPorId(long? Id, params Expression<Func<T, Object>>[] includeProperties);
        T ObtenerPorId(long? Id, string includeProperties);

        IEnumerable<T> ObtenerPorFlitro(Expression<Func<T, bool>> Predicado);
        IEnumerable<T> ObtenerPorFlitro(Expression<Func<T, bool>> Predicado, params Expression<Func<T, Object>>[] includeProperties);
        IEnumerable<T> ObtenerPorFlitro(Expression<Func<T, bool>> Predicado, string includeProperties);

        IList<T> ObtenerPorFlitro2(Expression<Func<T, bool>> Predicado, string includeProperties);
        IList<T> ObtenerPorFlitro2(Expression<Func<T, bool>> Predicado, params Expression<Func<T, Object>>[] includeProperties);
    }
}
