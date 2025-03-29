using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class CategoriaService : ServiceBase, ICategoriaService
    {
        private readonly ICategoriaServiceApiClient _serviceApiClient;

        public CategoriaService(ICategoriaServiceApiClient serviceApiClient)
        {
            _serviceApiClient = serviceApiClient;
        }

        public async Task<ResponseViewModel?> Create(CategoriaViewModel vm)
        {
            return await _serviceApiClient.Add(vm);
        }

        public async Task<ResponseViewModel?> GetAll()
        {
            var response = await _serviceApiClient.GetAll();

            if (response.IsSuccess)
                response.Result = DesearilizeList<CategoriaGetViewModel>(response);

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
                response.Result = Desearilize<CategoriaGetViewModel>(response);

            return response;
        }

        public async Task<ResponseViewModel?> SoftDelete(int id)
        {
            return await _serviceApiClient.SoftDelete(id);
        }

        public async Task<ResponseViewModel?> Update(CategoriaPutViewModel vm)
        {
            return await _serviceApiClient.Update(vm);
        }
    }
}
