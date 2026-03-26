using LXF.Web.Models.ViewModels;

namespace LXF.Web.Service.IService
{
    public interface IProvinciaService
    {
        Task<ResponseViewModel?> GetAll();
    }
}
