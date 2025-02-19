using DominioBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infraestructura.RepositorioBase
{
    public interface IRepository<T> : IRepositoryQuery<T>, IRepositoryOperations<T> where T : MasterEntityModel
    {
    }
}
