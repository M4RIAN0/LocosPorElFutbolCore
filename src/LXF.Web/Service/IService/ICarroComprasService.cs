using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{ 
    public interface ICarroComprasService
    {
        Task<ResponseViewModel?> Create(CarroComprasViewModel vm);
        Task<ResponseViewModel?> Update(CarroComprasPutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetByUserId(string id);
    }
}
