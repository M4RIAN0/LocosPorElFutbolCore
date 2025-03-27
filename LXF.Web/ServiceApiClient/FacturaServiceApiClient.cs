using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient
{
    public class FacturaServiceApiClient : IFacturaServiceApiClient
    {
        private readonly IServiceBaseApiClient _baseServiceApiClient;

        public FacturaServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
        {
            _baseServiceApiClient = ServiceApiClientBase;
        }

        public async Task<ResponseViewModel?> Add(FacturaViewModel ViewModel)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = ViewModel,
                Url = $"{SD.LXFApiBase}/api/Factura"
            });
        }

        public async Task<ResponseViewModel?> GetAll()
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Factura"
            });
        }

        public async Task<ResponseViewModel?> GetById(int? id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Factura/{id}"
            });
        }
    }
}
