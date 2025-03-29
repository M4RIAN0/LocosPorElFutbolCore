using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{ 
    public interface ICategoriaService
    {
        Task<ResponseViewModel?> Create(CategoriaViewModel vm);
        Task<ResponseViewModel?> Update(CategoriaPutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
        Task<ResponseViewModel?> GetByFilter(string cadena);
    }
}
