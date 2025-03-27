using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient
{
    public class PersonaClienteServiceApiClient : IPersonaClienteServiceApiClient
    {
        private readonly IServiceBaseApiClient _baseServiceApiClient;

        public PersonaClienteServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
        {
            _baseServiceApiClient = ServiceApiClientBase;
        }
        public async Task<ResponseViewModel?> Add(PersonaClienteViewModel ViewModel)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = ViewModel,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente"
            });
        }

        public async Task<ResponseViewModel?> GetAll()
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente"
            });
        }

        public async Task<ResponseViewModel?> GetByFilter(string cadenaBuscar)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente/GetByFilter{cadenaBuscar}"
            });
        }

        public async Task<ResponseViewModel?> GetById(int? id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente/{id}"
            });
        }

        public async Task<ResponseViewModel?> SoftDelete(int id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.PUT,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente/{id}/delete"
            });
        }

        public async Task<ResponseViewModel?> Update(PersonaClientePutViewModel ViewModel)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.PUT,
                Data = ViewModel,
                Url = $"{SD.LXFApiBase}/api/PersonaCliente/"
            });
        }
    }
}
