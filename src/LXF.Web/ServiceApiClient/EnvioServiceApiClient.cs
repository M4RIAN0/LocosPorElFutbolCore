using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;

namespace LXF.Web.ServiceApiClient
{
    public class EnvioServiceApiClient : IEnvioServiceApiClient
    {
        private readonly IServiceBaseApiClient _serviceBaseApiClient;

        public EnvioServiceApiClient(IServiceBaseApiClient serviceBaseApiClient)
        {
            _serviceBaseApiClient = serviceBaseApiClient;
        }

        public async Task<ResponseViewModel?> Add(EnvioViewModel vm)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel?> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel?> GetByFilter(string cadenaBuscar)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel?> SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel?> Update(EnvioViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
