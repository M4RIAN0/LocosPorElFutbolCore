using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface ICarroComprasServiceApiClient
    {
        Task<ResponseViewModel?> Add(CarroComprasViewModel vm);
        Task<ResponseViewModel?> Update(CarroComprasPutViewModel vm);
        Task<ResponseViewModel?> RemoveItem(int id);
        Task<ResponseViewModel?> GetByUserId(string userId);
    }
}
