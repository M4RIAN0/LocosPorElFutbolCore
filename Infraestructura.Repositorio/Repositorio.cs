using Dominio.Entidades;
using DominioBase;
using Infraestructura.RepositorioBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructura.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : EntidadBase
    {
        private LxfContext Context;

        public Repositorio(LxfContext context)
        {
            Context = context;
        }

        public void Agregar(T entidad)
        {
            Context.Set<T>().Add(entidad);
        }

        public void Eliminar(long id)
        {
            var obtener = ObtenerPorId(id);
            Context.Set<T>().Remove(obtener);
        }

        public void Modificar(T entidad)
        {
            Context.Set<T>().Attach(entidad);
            Context.Entry(entidad).State = EntityState.Modified;
        }

        //----------------------------------------------------------------------------------------//

        // Includes

        public IEnumerable<T> ObtenerPorFlitro(Expression<Func<T, bool>> Predicado)
        {
            return Context.Set<T>().AsNoTracking().Where(Predicado);
        }

        public IEnumerable<T> ObtenerPorFlitro(Expression<Func<T, bool>> Predicado, params Expression<Func<T, Object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query, (Current, includeProperty) => Current.Include(includeProperty));
            return query.AsNoTracking().ToList();
        }

        public IEnumerable<T> ObtenerPorFlitro(Expression<Func<T, bool>> Predicado, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();

            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }

            return query.AsNoTracking().ToList();
        }

        //----------------------------------------------------------------------------------------//

        // Includes

        public IList<T> ObtenerPorFlitro2(Expression<Func<T, bool>> Predicado, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();

            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }

            return query.AsNoTracking().ToList();
        }

        public IList<T> ObtenerPorFlitro2(Expression<Func<T, bool>> Predicado, params Expression<Func<T, Object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query, (Current, includeProperty) => Current.Include(includeProperty));
            return query.AsNoTracking().ToList();
        }

        //----------------------------------------------------------------------------------------//

        // Includes

        public T ObtenerPorId(long? Id)
        {
            return Context.Set<T>().Find(Id);
        }

        public T ObtenerPorId(long? Id, params Expression<Func<T, Object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = includeProperties.Aggregate(query, (Current, includeProperty) => Current.Include(includeProperty));
            return query.FirstOrDefault(X => X.Id == Id);
        }

        public T ObtenerPorId(long? Id, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();

            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault(X => X.Id == Id);
        }

        //----------------------------------------------------------------------------------------//

        // Includes

        public async Task<IEnumerable<T>> ObtenerTodo()
        {
          return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public IEnumerable<T> ObtenerTodo(params Expression<Func<T, Object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query, (Current, includeProperty) => Current.Include(includeProperty));
            return query.AsNoTracking().ToList();
        }

        public IEnumerable<T> ObtenerTodo(string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();

            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }

            return query.AsNoTracking().ToList();
        }

        //----------------------------------------------------------------------------------------//

        public void Save()
        {
            Context.SaveChanges();
        }

    }
}
