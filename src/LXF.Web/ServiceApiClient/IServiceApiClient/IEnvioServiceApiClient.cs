using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IEnvioServiceApiClient
    {
        Task<ResponseViewModel?> Add(EnvioViewModel vm);
        Task<ResponseViewModel?> Update(EnvioViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int Id);
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar); // obtener por filtro
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
    }
}
