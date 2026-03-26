using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient
{
    public class EnvioServiceApiClient : IEnvioServiceApiClient
    {
        private readonly IServiceBaseApiClient _baseServiceApiClient;

        public EnvioServiceApiClient(IServiceBaseApiClient serviceBaseApiClient)
        {
            _baseServiceApiClient = serviceBaseApiClient;
        }

        public async Task<ResponseViewModel?> GetByFilter(string cadenaBuscar)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Envio/GetByFilter{cadenaBuscar}"
            });
        }

        public async Task<ResponseViewModel?> GetById(int id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Envio/{id}"
            });
        }

    }
}
