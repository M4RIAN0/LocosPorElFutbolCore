using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IDetalleComprobanteServiceApiClient
    {
        Task<ResponseViewModel?> Add(DetalleComprobanteViewModel ViewModel);

        Task<ResponseViewModel?> GetById(int? id);
    }
}
