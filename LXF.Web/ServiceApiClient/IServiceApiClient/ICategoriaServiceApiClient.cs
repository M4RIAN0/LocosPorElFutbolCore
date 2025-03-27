using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface ICategoriaServiceApiClient
    {
        Task<ResponseViewModel?> Add(CategoriaViewModel ViewModel);
        Task<ResponseViewModel?> Update(CategoriaPutViewModel ViewModel);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int? id);
    }
}
