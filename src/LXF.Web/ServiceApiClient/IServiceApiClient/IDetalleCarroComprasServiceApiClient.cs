using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IDetalleCarroComprasServiceApiClient
    {
        Task<ResponseViewModel?> Add(DetalleCarroComprasViewModel vm);
    }
}
