using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IEnvioServiceApiClient
    {
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar);
        Task<ResponseViewModel?> GetById(int id);
    }
}
