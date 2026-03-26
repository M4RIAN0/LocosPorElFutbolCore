using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class EnvioService : ServiceBase, IEnvioService
    {
        private readonly IEnvioServiceApiClient _serviceApiClient;

        public EnvioService(IEnvioServiceApiClient serviceApiClient)
        {
            _serviceApiClient = serviceApiClient;
        }

        public async Task<ResponseViewModel?> GetByFilter(string cadena)
        {
            var response = await _serviceApiClient.GetByFilter(cadena);

            if (response.IsSuccess)
                response.Result = DesearilizeList<EnvioGetViewModel>(response);

            return response;
        }

        public async Task<ResponseViewModel?> GetById(int id)
        {
            var response = await _serviceApiClient.GetById(id);

            if (response.IsSuccess)
                response.Result = Desearilize<EnvioGetViewModel>(response);

            return response;
        }
    }
}
