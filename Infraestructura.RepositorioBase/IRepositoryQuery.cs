using DominioBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infraestructura.RepositorioBase
{
    public interface IRepositoryQuery<T> where T : MasterEntityModel
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, Object>>[] includeProperties);
        IEnumerable<T> GetAll(string includeProperties);

        T GetById(int? Id);
        T GetById(int? Id, params Expression<Func<T, Object>>[] includeProperties);
        T GetById(int? Id, string includeProperties);

        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includeProperties);
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate, string includeProperties);

        IList<T> GetByFilter2(Expression<Func<T, bool>> predicate, string includeProperties);
        IList<T> GetByFilter2(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includeProperties);

        IEnumerable<T> OrderByDescending(Expression<Func<T, Object>> predicate);
    }
}
