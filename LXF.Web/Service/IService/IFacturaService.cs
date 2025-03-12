using IServicio.Dtos;
using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface IFacturaService
    {
        Task<ResponseDto?> Add(FacturaDto dto);
        Task<ResponseDto?> GetAll();
        Task<ResponseDto?> GetById(int? id);
    }
}
