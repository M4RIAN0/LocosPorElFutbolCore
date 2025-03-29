using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface ITarjetaServiceApiClient
    {
        Task<ResponseViewModel?> Add(TarjetaViewModel vm);
        Task<ResponseViewModel?> GetById(int? id);
    }
}
