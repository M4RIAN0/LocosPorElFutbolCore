using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class VentaService : ServiceBase, IVentaService
    {
        private readonly IVentaServiceApiClient _serviceApiClient;

        public VentaService(IVentaServiceApiClient serviceApiClient)
        {
            _serviceApiClient = serviceApiClient;
        }
        
        public async Task<ResponseViewModel?> PersistObjects(TransactionObjectsViewModel vm)
        {
            return await _serviceApiClient.Add(vm);
        }

        public async Task<ResponseViewModel?> GetComprobantesByClienteId(int clienteId)
        {
            var response = await _serviceApiClient.GetComprobantesByClienteId(clienteId);

            if(response.IsSuccess)
                response.Result = DesearilizeList<ComprobanteGetViewModel>(response);

            return response;
        }

        public async Task<ResponseViewModel> GetComprobantebyId(int id)
        {
            var response = await _serviceApiClient.GetComprobanteById(id);

            if (response.IsSuccess)
                response.Result = Desearilize<ComprobanteGetViewModel>(response);

            return response;
        }
    }
}
