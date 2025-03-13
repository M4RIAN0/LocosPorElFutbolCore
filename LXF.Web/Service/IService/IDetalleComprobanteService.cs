using IServicio.Dtos;
using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface IDetalleComprobanteService
    {
        Task<ResponseDto?> Add(DetalleComprobanteDto dto);

        Task<ResponseDto?> GetById(int? id);
    }
}
