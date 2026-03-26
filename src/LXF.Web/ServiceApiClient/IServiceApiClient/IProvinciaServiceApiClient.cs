using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IProvinciaServiceApiClient
    {
        Task<ResponseViewModel?> GetAll();
    }
}
