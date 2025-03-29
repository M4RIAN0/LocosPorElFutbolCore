using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IMarcaServiceApiClient
    {
        Task<ResponseViewModel?> Add(MarcaViewModel vm);
        Task<ResponseViewModel?> Update(MarcaPutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar);
        Task<ResponseViewModel?>GetAll();
        Task<ResponseViewModel?> GetById(int? id);

    }
}
