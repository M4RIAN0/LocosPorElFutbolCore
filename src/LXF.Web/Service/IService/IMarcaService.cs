using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{
    public interface IMarcaService
    {
        Task<ResponseViewModel?> Create(MarcaViewModel vm);
        Task<ResponseViewModel?> Update(MarcaPutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
        Task<ResponseViewModel?> GetByFilter(string cadena);
    }
}
