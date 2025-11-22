using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient
{
    public class MarcaServiceApiClient : IMarcaServiceApiClient
    {
        private readonly IServiceBaseApiClient _baseServiceApiClient;

        public MarcaServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
        {
            _baseServiceApiClient = ServiceApiClientBase;
        }

        public async Task<ResponseViewModel?> Add(MarcaViewModel vm)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = vm,
                Url = $"{SD.LXFApiBase}/api/Marca"
            });
        }

        public async Task<ResponseViewModel?> GetAll()
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Marca"
            });
        }

        public async Task<ResponseViewModel?> GetByFilter(string cadenaBuscar)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET, 
                Url = $"{SD.LXFApiBase}/api/Marca/GetByFilter{cadenaBuscar}" 
            });
        }

        public async Task<ResponseViewModel?> GetById(int id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Marca/{id}"
            });
        }

        public async Task<ResponseViewModel?> SoftDelete(int id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.PUT,
                Url = $"{SD.LXFApiBase}/api/Marca/{id}/delete"
            });
        }

        public async Task<ResponseViewModel?> Update(MarcaPutViewModel vm)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.PUT,
                Data = vm,
                Url = $"{SD.LXFApiBase}/api/Marca/"
            });
        }
    }
}