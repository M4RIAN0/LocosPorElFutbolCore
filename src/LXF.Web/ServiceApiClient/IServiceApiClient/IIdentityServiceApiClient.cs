using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IIdentityServiceApiClient
    {
        Task<ResponseViewModel?> LoginAsync(LoginRequestViewModel vm);
        Task<ResponseViewModel?> RegsiterAsync(RegisterRequestViewModel vm);
        Task<ResponseViewModel?> AssignRoleAsync(RegisterRequestViewModel vm);
    }
}
