using IServicio.Dtos;
using LXF.Web.Models.Dto;
using LXF.Web.Service.IService;
using LXF.Web.Utility;

namespace LXF.Web.Service
{
    public class DetalleComprobanteService : IDetalleComprobanteService
    {
        private readonly IServiceBase _baseService;

        public DetalleComprobanteService(IServiceBase serviceBase)
        {
            _baseService = serviceBase;
        }

        public async Task<ResponseDto?> Add(DetalleComprobanteDto dto)
        {

            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = $"{SD.LXFApiBase}/api/DetalleComprobante"
            });
        }

        public async Task<ResponseDto?> GetById(int? id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/DetalleComprobante/{id}"
            });
        }
    }
}
