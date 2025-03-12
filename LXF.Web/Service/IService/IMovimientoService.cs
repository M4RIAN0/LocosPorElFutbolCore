using IServicio.Dtos;
using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface IMovimientoService
    {
        Task<ResponseDto?> Add(MovimientoDto dto);
        Task<ResponseDto?> GetById(int? id);
    }
}
