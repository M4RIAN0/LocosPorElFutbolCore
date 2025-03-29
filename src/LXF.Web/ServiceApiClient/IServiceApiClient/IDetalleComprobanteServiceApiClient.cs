using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IDetalleComprobanteServiceApiClient
    {
        Task<ResponseViewModel?> Add(DetalleComprobanteViewModel vm);

        Task<ResponseViewModel?> GetById(int? id);
    }
}
