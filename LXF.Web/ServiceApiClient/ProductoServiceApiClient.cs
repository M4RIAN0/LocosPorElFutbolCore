using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient
{
    public class ProductoServiceApiClient : IProductoServiceApiClient
    {
        private readonly IServiceBaseApiClient _baseServiceApiClient;

        public ProductoServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
        {
            _baseServiceApiClient = ServiceApiClientBase;
        }
        public async Task<ResponseViewModel?> Add(ProductoViewModel ViewModel)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = ViewModel,
                Url = $"{SD.LXFApiBase}/api/Producto"
            });
        }

        public async Task<ResponseViewModel?> GetAll()
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Producto"
            });
        }

        public async Task<ResponseViewModel?> GetByFilter(string cadenaBuscar)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Producto/GetByFilter{cadenaBuscar}"
            });
        }

        public async Task<ResponseViewModel?> GetById(int? id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.LXFApiBase}/api/Producto/{id}"
            });
        }

        public async Task<ResponseViewModel?> SoftDelete(int id)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.PUT,
                Url = $"{SD.LXFApiBase}/api/Producto/{id}/delete"
            });
        }

        public async Task<ResponseViewModel?> Update(ProductoPutViewModel ViewModel)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.PUT,
                Data = ViewModel,
                Url = $"{SD.LXFApiBase}/api/Producto/"
            });
        }
    }
}
