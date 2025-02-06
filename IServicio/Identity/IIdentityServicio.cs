using IServicio.Email;
using IServicio.Identity.Dto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IServicio.Identity
{
    public interface IIdentityServicio
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login (LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
        Task<UserToken> ForgotPassword(string email);
        Task<IdentityResult> ResetPassword(string email, string token, string password);
        bool SendMail(UserToken userToken, Message message);
    }
}
