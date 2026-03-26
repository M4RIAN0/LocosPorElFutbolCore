using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class PersonaClienteService : ServiceBase, IPersonaClienteService
    {
        private readonly IPersonaClienteServiceApiClient _serviceApiClient;
        private readonly IMapper _mapper;

        public PersonaClienteService(IPersonaClienteServiceApiClient serviceApiClient, IMapper mapper)
        {
            _serviceApiClient = serviceApiClient;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel?> GetByFilter(string word)
        {
            var response = await _serviceApiClient.GetByFilter(word);

            if (response.IsSuccess)
                response.Result = DesearilizeList<PersonaClienteGetViewModel>(response);

            return response;

        }
    }
}
