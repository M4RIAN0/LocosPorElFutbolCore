using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.Service
{
    public class TalleService : ServiceBase, ITalleService
    {
        private readonly ITalleServiceApiClient _service;
        private readonly IMapper _mapper;

        public TalleService(ITalleServiceApiClient service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel?> GetAll()
        {
            var response = await _service.GetAll();

            if (response.IsSuccess)
                response.Result = DesearilizeList<TalleViewModel>(response);

            return response;
        }

        public async Task<ResponseViewModel?> GetByFilter(string cadena)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel?> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
