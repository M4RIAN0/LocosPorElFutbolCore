using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient
{
    public class IdentityServiceApiClient : IIdentityServiceApiClient
    {
        private readonly IServiceBaseApiClient _baseServiceApiClient;

        public IdentityServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
        {
            _baseServiceApiClient = ServiceApiClientBase;
        }

        public async Task<ResponseViewModel?> AssignRoleAsync(RegisterRequestViewModel ViewModel)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = ViewModel,
                Url = $"{SD.LXFApiBase}/api/Identity/AssignRole"
            });
        }

        public async Task<ResponseViewModel?> LoginAsync(LoginRequestViewModel ViewModel)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = ViewModel,
                Url = $"{SD.LXFApiBase}/api/Identity/Login"
            });
        }

        public async Task<ResponseViewModel?> RegsiterAsync(RegisterRequestViewModel ViewModel)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = ViewModel,
                Url = $"{SD.LXFApiBase}/api/Identity/Register"
            });
        }
    }
}
