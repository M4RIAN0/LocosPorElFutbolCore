using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface ITalleServiceApiClient
    {
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
    }
}
