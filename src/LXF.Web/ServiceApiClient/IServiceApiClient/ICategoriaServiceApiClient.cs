using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface ICategoriaServiceApiClient
    {
        Task<ResponseViewModel?> Add(CategoriaViewModel vm);
        Task<ResponseViewModel?> Update(CategoriaPutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int? id);
    }
}
