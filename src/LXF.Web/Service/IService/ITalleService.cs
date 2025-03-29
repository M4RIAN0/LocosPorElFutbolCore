using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{
    public interface ITalleService
    {
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
        Task<ResponseViewModel?> GetByFilter(string cadena);
    }
}
