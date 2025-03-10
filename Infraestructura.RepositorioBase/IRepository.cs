using DominioBase;

namespace Infraestructura.RepositorioBase
{
    public interface IRepository<T> : IRepositoryQuery<T>, IRepositoryOperations<T> where T : MasterEntityModel
    {
    }
}
