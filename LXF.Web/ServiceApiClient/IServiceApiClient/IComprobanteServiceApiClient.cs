using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IComprobanteServiceApiClient
    {
        Task<ResponseViewModel?> Add(ComprobanteViewModel ViewModel);
    }
}
