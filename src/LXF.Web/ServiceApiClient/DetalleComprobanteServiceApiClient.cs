using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient
{
    public class DetalleComprobanteServiceApiClient : IDetalleComprobanteServiceApiClient
    {
        private readonly IServiceBaseApiClient _baseServiceApiClient;

        public DetalleComprobanteServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
        {
            _baseServiceApiClient = ServiceApiClientBase;
        }

        public async Task<ResponseViewModel?> Add(DetalleComprobanteViewModel vm)
        {

            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = vm,
                Url = $"{SD.LXFApiBase}/api/DetalleComprobante"
            });
        }

        public async Task<ResponseViewModel?> GetById(int id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/DetalleComprobante/{id}"
            });
        }
    }
}
