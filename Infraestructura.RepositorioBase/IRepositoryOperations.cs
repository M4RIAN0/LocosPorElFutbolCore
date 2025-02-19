using DominioBase;

namespace Infraestructura.RepositorioBase
{
    public interface IRepositoryOperations<T> where T : MasterEntityModel
    {
        void Add(T entity);
        void Edit(T entity);
        void SoftDelete(int id);
        void Save();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
