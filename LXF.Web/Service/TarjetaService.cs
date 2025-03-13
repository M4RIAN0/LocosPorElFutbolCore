using IServicio.Dtos;
using LXF.Web.Models.Dto;
using LXF.Web.Service.IService;
using LXF.Web.Utility;

namespace LXF.Web.Service
{
    public class TarjetaService : ITarjetaService
    {
        private readonly IServiceBase _baseService;

        public TarjetaService(IServiceBase serviceBase)
        {
            _baseService = serviceBase;
        }

        public async Task<ResponseDto?> Add(TarjetaDto dto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = $"{SD.LXFApiBase}/api/Tarjeta"
            });
        }

        public async Task<ResponseDto?> GetById(int? id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Tarjeta/{id}"
            });
        }
    }
}
