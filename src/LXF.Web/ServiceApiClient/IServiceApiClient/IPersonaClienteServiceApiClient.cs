using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IPersonaClienteServiceApiClient
    {
        Task<ResponseViewModel?> Add(PersonaClienteViewModel vm);
        Task<ResponseViewModel?> Update(PersonaClientePutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
    }
}
