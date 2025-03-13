using IServicio.Dtos;
using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface IComprobanteService
    {
        Task<ResponseDto?> Add(ComprobanteDto dto);
    }
}
