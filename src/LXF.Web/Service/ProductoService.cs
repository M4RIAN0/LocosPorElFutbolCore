using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class ProductoService : ServiceBase, IProductoService
    {
        private readonly IProductoServiceApiClient _serviceApiClient;
        private readonly ICategoriaService _categoriaService;
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;

        public ProductoService(IProductoServiceApiClient serviceApiClient, ICategoriaService categoriaService,
                               IMarcaService marcaService, IMapper mapper)
        {
            _serviceApiClient = serviceApiClient;
            _categoriaService = categoriaService;
            _marcaService = marcaService;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel?> Create(ProductoViewModel vm)
        {
            return await _serviceApiClient.Add(vm);
        }

        public async Task<ResponseViewModel?> Update(ProductoPutViewModel vm)
        {
            return await _serviceApiClient.Update(vm);
        }

        public async Task<ResponseViewModel?> SoftDelete(int id)
        {
            return await _serviceApiClient.SoftDelete(id);
        }

        public async Task<ResponseViewModel?> GetAll()
        {
            var response = await _serviceApiClient.GetAll();

            if (response.IsSuccess)
                response.Result = DesearilizeList<ProductoGetViewModel>(response);

            return response;
        }

        public async Task<ResponseViewModel?> GetById(int id)
        {
            var response = await _serviceApiClient.GetById(id);

            if (response.IsSuccess)
                response.Result = Desearilize<ProductoGetViewModel>(response);

            return response;
        }

        public async Task<ResponseViewModel?> GetByFilter(string cadena)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel?> GetMarcas()
        {
            return await _marcaService.GetAll();
        }

        public async Task<ResponseViewModel?> GetCategorias()
        {
            return await _categoriaService.GetAll();
        }
    }
}
