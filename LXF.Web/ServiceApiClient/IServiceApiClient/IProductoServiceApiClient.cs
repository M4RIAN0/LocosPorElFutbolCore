using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IProductoServiceApiClient
    {
        Task<ResponseViewModel?> Add(ProductoViewModel ViewModel);
        Task<ResponseViewModel?> Update(ProductoPutViewModel ViewModel);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int? id);
    }
}
