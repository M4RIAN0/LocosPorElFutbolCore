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

        public async Task<ResponseViewModel?> GetAll()
        {
            var response = await _serviceApiClient.GetAll();

            if (response.IsSuccess)
                response.Result = DesearilizeList<DetalleCarroComprasGetViewModel>(response);

            return response;
        }

        public Task<ResponseViewModel?> GetByFilter(string cadena)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel?> GetById(int id)
        {
            var response = await _serviceApiClient.GetById(id);

            if (response.IsSuccess)
                response.Result = Desearilize<DetalleCarroComprasGetViewModel>(response);

            return response;
        }

        public async Task<ResponseViewModel?> SoftDelete(int id)
        {
            return await _serviceApiClient.SoftDelete(id);
        }

        public async Task<ResponseViewModel?> Update(DetalleCarroComprasPutViewModel vm)
        {
            return await _serviceApiClient.Update(vm);
        }
    }
}
