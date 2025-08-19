using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{ 
    public interface IDetalleCarroComprasService
    {
        Task<ResponseViewModel?> Create(DetalleCarroComprasViewModel vm);
        Task<ResponseViewModel?> Update(DetalleCarroComprasPutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
        Task<ResponseViewModel?> GetByFilter(string cadena);
    }
}
