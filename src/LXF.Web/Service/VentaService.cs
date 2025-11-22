using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class VentaService : ServiceBase, IVentaService
    {
        private readonly IVentaServiceApiClient _serviceApiClient;
        private readonly IMapper _mapper;

        public VentaService(IVentaServiceApiClient serviceApiClient, IMapper mapper)
        {
            _serviceApiClient = serviceApiClient;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel?> PersistObjects(TransactionObjectsViewModel vm)
        {
            return await _serviceApiClient.Add(vm);
        }
    }
}
