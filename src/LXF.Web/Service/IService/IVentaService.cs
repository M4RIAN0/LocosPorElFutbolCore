using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{
    public interface IVentaService
    {
        Task<ResponseViewModel?> PersistObjects(TransactionObjectsViewModel vm);
    }
}
