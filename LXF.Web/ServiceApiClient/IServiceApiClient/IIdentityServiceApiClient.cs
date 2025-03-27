using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IIdentityServiceApiClient
    {
        Task<ResponseViewModel?> LoginAsync(LoginRequestViewModel ViewModel);
        Task<ResponseViewModel?> RegsiterAsync(RegisterRequestViewModel ViewModel);
        Task<ResponseViewModel?> AssignRoleAsync(RegisterRequestViewModel ViewModel);
    }
}
