using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IFacturaServiceApiClient
    {
        Task<ResponseViewModel?> Add(FacturaViewModel vm);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int? id);
    }
}
