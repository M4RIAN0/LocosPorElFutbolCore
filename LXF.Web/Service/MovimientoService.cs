using IServicio.Dtos;
using LXF.Web.Models.Dto;
using LXF.Web.Service.IService;
using LXF.Web.Utility;

namespace LXF.Web.Service
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IServiceBase _baseService;

        public MovimientoService(IServiceBase serviceBase)
        {
            _baseService = serviceBase;
        }

        public async Task<ResponseDto?> Add(MovimientoDto dto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = $"{SD.LXFApiBase}/api/Movimiento"
            });
        }

        public async Task<ResponseDto?> GetById(int? id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Movimiento/{id}"
            });
        }
    }
}
