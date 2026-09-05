using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{
    public interface IProductoService
    {
        Task<ResponseViewModel?> Create(ProductoViewModel vm);
        Task<ResponseViewModel?> Update(ProductoPutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
        Task<ResponseViewModel?> GetByFilter(string cadena);
        Task<ResponseViewModel?> GetMarcas();
        Task<ResponseViewModel?> GetCategorias();
    }
}