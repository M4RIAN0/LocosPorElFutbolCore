using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{
    public interface IEnvioService
    {
        Task<ResponseViewModel?> GetById(int id);
        Task<ResponseViewModel?> GetByFilter(string cadena);
    }
}
