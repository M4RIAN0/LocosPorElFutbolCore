using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{
    public interface IProductoService
    {
        Task<ResponseViewModel?> Create(ProductoViewModel ViewModel);
        Task<ResponseViewModel?> Update(ProductoPutViewModel ViewModel);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
        Task<ResponseViewModel?> GetByFilter(string cadena);
        Task<ResponseViewModel?> GetMarcas();
        Task<ResponseViewModel?> GetTalles();
        Task<ResponseViewModel?> GetCategorias();
    }
}