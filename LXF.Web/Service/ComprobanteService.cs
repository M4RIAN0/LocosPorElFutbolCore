using IServicio.Dtos;
using LXF.Web.Models.Dto;
using LXF.Web.Service.IService;
using LXF.Web.Utility;

namespace LXF.Web.Service
{
    public class ComprobanteService : IComprobanteService
    {
        private readonly IServiceBase _baseService;

        public ComprobanteService(IServiceBase serviceBase)
        {
            _baseService = serviceBase;
        }
        public async Task<ResponseDto?> Add(ComprobanteDto dto)
        {

            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST, 
                Data = dto, 
                Url = $"{SD.LXFApiBase}/api/Comprobante" 
            });
        }
    }
}
