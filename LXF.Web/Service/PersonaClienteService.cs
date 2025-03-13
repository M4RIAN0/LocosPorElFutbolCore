using IServicio.Dtos;
using LXF.Web.Models.Dto;
using LXF.Web.Service.IService;
using LXF.Web.Utility;

namespace LXF.Web.Service
{
    public class PersonaClienteService : IPersonaClienteService
    {
        private readonly IServiceBase _baseService;

        public PersonaClienteService(IServiceBase serviceBase)
        {
            _baseService = serviceBase;
        }
        public async Task<ResponseDto?> Add(PersonaClienteDto dto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente"
            });
        }

        public async Task<ResponseDto?> GetAll()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente"
            });
        }

        public async Task<ResponseDto?> GetByFilter(string cadenaBuscar)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente/GetByFilter{cadenaBuscar}"
            });
        }

        public async Task<ResponseDto?> GetById(int? id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente/{id}"
            });
        }

        public async Task<ResponseDto?> SoftDelete(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente/{id}/delete"
            });
        }

        public async Task<ResponseDto?> Update(PersonaClientePutDto dto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente/"
            });
        }
    }
}
