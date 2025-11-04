using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{ 
    public interface ICarroComprasService
    {
        Task<ResponseViewModel?> Create(CarroComprasViewModel vm);
        Task<ResponseViewModel?> Update(CarroComprasPutViewModel vm);
        Task<ResponseViewModel?> RemoveItem(int id);
        Task<ResponseViewModel?> GetByUserId(string id);
    }
}
