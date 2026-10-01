using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{ 
    public interface ICarroComprasService
    {
        Task<ResponseViewModel?> Create(CarroComprasViewModel vm);
        Task<ResponseViewModel?> Update(CarroComprasPutViewModel id);
        Task<ResponseViewModel?> AddItem(int id);
        Task<ResponseViewModel?> SubtractItem(int id);
        Task<ResponseViewModel?> Remove(int id);
        Task<ResponseViewModel?> RemoveItem(int id);
        Task<ResponseViewModel?> GetByUserId(string id);
        Task<ResponseViewModel?> GetAnyWithProductId(int productId);
    }
}
