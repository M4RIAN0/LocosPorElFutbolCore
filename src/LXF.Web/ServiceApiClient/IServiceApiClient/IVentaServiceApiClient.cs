using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IVentaServiceApiClient
    {
        Task<ResponseViewModel?> Add(TransactionObjectsViewModel vm);
    }
}
