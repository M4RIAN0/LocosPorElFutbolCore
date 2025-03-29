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

        public async Task<ResponseViewModel?> AssignRoleAsync(RegisterRequestViewModel vm)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = vm,
                Url = $"{SD.LXFApiBase}/api/Identity/AssignRole"
            });
        }

        public async Task<ResponseViewModel?> LoginAsync(LoginRequestViewModel vm)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = vm,
                Url = $"{SD.LXFApiBase}/api/Identity/Login"
            });
        }

        public async Task<ResponseViewModel?> RegsiterAsync(RegisterRequestViewModel vm)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = vm,
                Url = $"{SD.LXFApiBase}/api/Identity/Register"
            });
        }
    }
}
