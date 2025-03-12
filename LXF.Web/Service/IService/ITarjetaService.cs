using IServicio.Dtos;
using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface ITarjetaService
    {
        Task<ResponseDto?> Add(TarjetaDto dto);
        Task<ResponseDto?> GetById(int? id);
    }
}
