using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class DetalleCarroComprasService : ServiceBase, IDetalleCarroComprasService
    {
        private readonly IDetalleCarroComprasServiceApiClient _serviceApiClient;

        public DetalleCarroComprasService(IDetalleCarroComprasServiceApiClient serviceApiClient)
        {
            _serviceApiClient = serviceApiClient;
        }

        public async Task<ResponseViewModel?> Create(DetalleCarroComprasViewModel vm)
        {
            return await _serviceApiClient.Add(vm);
        }
    }
}
