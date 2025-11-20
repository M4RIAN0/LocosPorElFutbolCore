using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IMovimientoServiceApiClient
    {
        Task<ResponseViewModel?> Add(MovimientoViewModel vm);
        Task<ResponseViewModel?> GetById(int id);
    }
}
