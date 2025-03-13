using LXF.Web.Models.Dto;
using LXF.Web.Service.IService;
using LXF.Web.Utility;

namespace LXF.Web.Service
{
    public class TalleService : ITalleService
    {
        private readonly IServiceBase _baseService;

        public TalleService(IServiceBase serviceBase)
        {
            _baseService = serviceBase;
        }

        public async Task<ResponseDto?> GetAll()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Talle"
            });
        }

        public async Task<ResponseDto?> GetByFilter(string cadenaBuscar)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Talle/GetByFilter{cadenaBuscar}"
            });
        }

        public async Task<ResponseDto?> GetById(int? id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Talle/{id}"
            });
        }
    }

}
