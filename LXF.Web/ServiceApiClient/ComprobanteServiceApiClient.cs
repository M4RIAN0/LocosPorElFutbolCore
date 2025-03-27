using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient
{
    public class ComprobanteServiceApiClient : IComprobanteServiceApiClient
    {
        private readonly IServiceBaseApiClient _baseServiceApiClient;

        public ComprobanteServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
        {
            _baseServiceApiClient = ServiceApiClientBase;
        }
        public async Task<ResponseViewModel?> Add(ComprobanteViewModel ViewModel)
        {

            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST, 
                Data = ViewModel, 
                Url = $"{SD.LXFApiBase}/api/Comprobante" 
            });
        }
    }
}
