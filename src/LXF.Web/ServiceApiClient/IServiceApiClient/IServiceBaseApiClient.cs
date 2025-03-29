using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IServiceBaseApiClient
    {
        Task<ResponseViewModel?> SendAsync(RequestViewModel requestViewModel, bool withBearer = true);
    }
}
