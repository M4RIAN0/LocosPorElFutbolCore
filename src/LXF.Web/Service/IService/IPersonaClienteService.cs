using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{
    public interface IPersonaClienteService
    {
        Task<ResponseViewModel?> GetByFilter(string word);
    }
}
