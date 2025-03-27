using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient
{
    public class MovimientoServiceApiClient : IMovimientoServiceApiClient
    {
        private readonly IServiceBaseApiClient _baseServiceApiClient;

        public MovimientoServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
        {
            _baseServiceApiClient = ServiceApiClientBase;
        }

        public async Task<ResponseViewModel?> Add(MovimientoViewModel ViewModel)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = ViewModel,
                Url = $"{SD.LXFApiBase}/api/Movimiento"
            });
        }

        public async Task<ResponseViewModel?> GetById(int? id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Movimiento/{id}"
            });
        }
    }
}
