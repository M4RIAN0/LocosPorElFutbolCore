using IServicio.Email;
using IServicio.Identity.Dto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IServicio.Identity
{
    public interface IIdentityService
    {
        Task<UsuarioDto> Register(RegisterDto registerDto);
        Task<LoginResponseDto> Login (LoginDto loginDto);
        Task<IdentityResult> AssignRole(string email, string roleName);
        Task<UserToken> TokenPassword(string email);
        Task<IdentityResult> ResetPassword(string email, string token, string password);
        bool SendMail(UserToken userToken, Message message);
    }
}
