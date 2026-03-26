using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{
    public interface IVentaService
    {
        Task<ResponseViewModel?> PersistObjects(TransactionObjectsViewModel vm);

        Task<ResponseViewModel> GetComprobantesByClienteId(int clienteId);

        Task<ResponseViewModel> GetComprobantebyId(int id);
    }
}
