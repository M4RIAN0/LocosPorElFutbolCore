using DominioBase;
using Infraestructura.RepositorioBase;
using Lxf.Support.BuildingBlocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Infraestructura.Repositorio.repository
{
    public class Repository<T> : IRepository<T> where T : MasterEntityModel
    {
        protected LxfContext _context;
        protected IDbContextTransaction _transaction;

        public Repository(LxfContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            var modelErrors = CheckProperties(entity);

            if (modelErrors.Count > 0)
                throw new BadRequestException(modelErrors);

            _context.Set<T>().Add(entity);
        }

        public void Attach(T entity)
        {
            var exist = _context.Set<T>().Where(x => x.ID == entity.ID && !x.IsDeleted).Any();

            if (!exist)
                throw new ElementNotFoundException($"No se encontro {typeof(T).Name} con el Id: {entity.ID}.");

            var ModelErrors = CheckProperties(entity);

            if (ModelErrors.Count > 0)
                throw new BadRequestException(ModelErrors);

            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void SoftDelete(int id)
        {
            var model = _context.Set<T>().Where(x => x.ID == id && !x.IsDeleted).FirstOrDefault();

            if (model == null)
                throw new ElementNotFoundException($"No se encontro {typeof(T).Name} con el Id: {id}.");

            model.IsDeleted = true;
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return [.. _context.Set<T>().AsNoTracking().Where(predicate).Where(x => !x.IsDeleted)];
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query, (Current, includeProperty) => Current.Include(includeProperty));
            return [.. query.AsNoTracking().Where(x => !x.IsDeleted)];
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate, string includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }

            return [.. query.AsNoTracking().Where(x => !x.IsDeleted)];
        }

        public IList<T> GetByFilter2(Expression<Func<T, bool>> predicate, string includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }

            return [.. query.AsNoTracking().Where(x => !x.IsDeleted)];
        }

        public IList<T> GetByFilter2(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query, (Current, includeProperty) => Current.Include(includeProperty));
            return [.. query.AsNoTracking().Where(x => !x.IsDeleted)];
        }

        public T GetById(int? id)
        {
            var model = _context.Set<T>().Where(x => x.ID == id && !x.IsDeleted).FirstOrDefault();

            if (model == null)
                throw new ElementNotFoundException($"No se encontro {typeof(T).Name} con el Id: {id}.");

            return model;
        }

        public T GetById(int? id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            query = includeProperties.Aggregate(query, (Current, includeProperty) => Current.Include(includeProperty));

            var model = query.FirstOrDefault(x => x.ID == id && !x.IsDeleted);

            if (model == null)
                throw new ElementNotFoundException($"No se encontro {typeof(T).Name} con el Id: {id}.");

            return model;
        }

        public T GetById(int? id, string includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }

            var model = query.FirstOrDefault(x => x.ID == id && !x.IsDeleted);

            if (model == null)
                throw new ElementNotFoundException($"No se encontro {typeof(T).Name} con el Id: {id}.");

            return model;
        }

        public IEnumerable<T> GetAll()
        {
            return [.. _context.Set<T>().AsNoTracking().Where(x => !x.IsDeleted)];
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query, (Current, includeProperty) => Current.Include(includeProperty));
            return [.. query.AsNoTracking().Where(x => !x.IsDeleted)];
        }

        public IEnumerable<T> GetAll(string includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }

            return [.. query.AsNoTracking().Where(x => !x.IsDeleted)];
        }

        public IEnumerable<T> OrderByDescending(Expression<Func<T, Object>> predicate)
        {
            return [.. _context.Set<T>().AsNoTracking().Where(x => !x.IsDeleted).OrderByDescending(predicate)];
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction() => _transaction = _context.Database.BeginTransaction();

        public void Commit() { if (_transaction != null) { _transaction.Commit(); _transaction.Dispose(); } }

        public void Rollback() { if (_transaction != null) { _transaction.Rollback(); _transaction.Dispose(); } }

        protected static Dictionary<string, string> CheckProperties(object obj)
        {
            var props = new Dictionary<string, string>();

            if (obj == null)
            {
                props.Add(typeof(T).Name, "Cannot add a null element");
            }
            else
            {
                var context = new ValidationContext(obj, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(obj, context, results, validateAllProperties: true);

                foreach (var item in results)
                {
                    string key = item.MemberNames.First();
                    if (!props.ContainsKey(key)) props.Add(key, item.ErrorMessage ?? "");
                }
            }
            return props;
        }
    }
}
