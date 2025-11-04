using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class CarroComprasService : ServiceBase, ICarroComprasService
    {
        private readonly ICarroComprasServiceApiClient _serviceApiClient;

        public CarroComprasService(ICarroComprasServiceApiClient serviceApiClient)
        {
            _serviceApiClient = serviceApiClient;
        }

        public async Task<ResponseViewModel?> Create(CarroComprasViewModel vm)
        {
            return await _serviceApiClient.Add(vm);
        }

        public async Task<ResponseViewModel?> GetByUserId(string id)
        {
            var response = await _serviceApiClient.GetByUserId(id);

            if (response.IsSuccess)
                response.Result = Desearilize<CarroComprasGetViewModel>(response);

            return response;
        }

        public async Task<ResponseViewModel?> RemoveItem(int id)
        {
            return await _serviceApiClient.RemoveItem(id);
        }

        public async Task<ResponseViewModel?> Update(CarroComprasPutViewModel vm)
        {
          return await _serviceApiClient.Update(vm);
        }
    }
}
