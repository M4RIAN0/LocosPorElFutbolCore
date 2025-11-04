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
            }, withBearer: false); // no pasa el token porque no es necesario en esta instancia y ademas no esta siendo generado (no se esta loggeando)
        }

        public async Task<ResponseViewModel?> LoginAsync(LoginRequestViewModel vm)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = vm,
                Url = $"{SD.LXFApiBase}/api/Identity/Login"
            }, withBearer: false);
        }

        public async Task<ResponseViewModel?> RegsiterAsync(RegisterRequestViewModel vm)
        {
            return await _baseServiceApiClient.SendAsync(new RequestViewModel
            {
                ApiType = SD.ApiType.POST,
                Data = vm,
                Url = $"{SD.LXFApiBase}/api/Identity/Register"
            }, withBearer: false);
        }
    }
}
