using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class ProvinciaService : ServiceBase, IProvinciaService
    {
        private readonly IProvinciaServiceApiClient _serviceApiClient;
        private readonly IMapper _mapper;

        public ProvinciaService(IProvinciaServiceApiClient serviceApiClient, IMapper mapper)
        {
            _serviceApiClient = serviceApiClient;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel?> GetAll()
        {
            var response =  await _serviceApiClient.GetAll();

            if (response.IsSuccess)
                response.Result = DesearilizeList<ProvinciaGetViewModel>(response);

            return response;

        }
    }
}
