using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface ITalleService
    {
        Task<ResponseDto?> GetByFilter(string cadenaBuscar);
        Task<ResponseDto?> GetAll();
        Task<ResponseDto?> GetById(int? id);
    }
}
