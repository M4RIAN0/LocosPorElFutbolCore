using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface ITarjetaServiceApiClient
    {
        Task<ResponseViewModel?> Add(TarjetaViewModel ViewModel);
        Task<ResponseViewModel?> GetById(int? id);
    }
}
