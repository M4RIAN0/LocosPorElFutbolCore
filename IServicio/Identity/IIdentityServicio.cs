using IServicio.Identity.Dto;
using System.Threading.Tasks;

namespace IServicio.Identity
{
    public interface IIdentityServicio
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login (LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
