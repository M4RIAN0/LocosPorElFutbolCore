using AutoMapper;
using Dominio.Entidades;
using Infraestructura;
using IServicio.Email;
using IServicio.Identity;
using IServicio.Identity.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Identity
{
    public class IndentityServicio : IIdentityServicio
    {
        private readonly LxfContext _db;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public IndentityServicio(LxfContext db, UserManager<Usuario> userManager, RoleManager<Role> roleManager, IEmailSender emailSender, IMapper mapper)
        {
           _db = db;
           _userManager = userManager;
           _roleManager = roleManager;
           _emailSender = emailSender;
           _mapper = mapper;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.Usuario.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new Role() { Name = roleName}).GetAwaiter().GetResult();
                }

                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }

            return false;
        }


        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.Usuario.FirstOrDefault(x => x.UserName.ToLower() == loginRequestDto.NombreUsuario);

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { Usuario = null};
            }

            UsuarioDto userDto = _mapper.Map<UsuarioDto>(user);

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                Usuario = userDto
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            Usuario usuario = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Nombre = registrationRequestDto.Nombre,
                PhoneNumber = registrationRequestDto.Celular
            };

            var result = await _userManager.CreateAsync(usuario, registrationRequestDto.Password);

            if (result.Succeeded)
            {
                var userToReturn = _db.Usuario.First(x => x.UserName == registrationRequestDto.Email);

                UsuarioDto usuarioDto = new()
                {
                    EMAIL = registrationRequestDto.Email,
                    ID = userToReturn.Id,
                    Nombre = userToReturn.Nombre,
                    Celular = userToReturn.PhoneNumber
                };

                return "";
            }
            else
            {
                return result.Errors.FirstOrDefault().Description;
            }
        }
    
        public async Task<UserToken> ForgotPassword(string email)
        {
            var user = _db.Usuario.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                return new UserToken() { User = user.Email, Token = token };
            }

            return new UserToken();
        }

        public async Task<IdentityResult> ResetPassword(string email, string token, string password)
        {
            var user = _db.Usuario.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, token, password);
                if (result.Succeeded)
                    return result;
            }
            return new IdentityResult();
        }

        public bool SendMail(UserToken userToken, Message message)
        {
            if (string.IsNullOrEmpty(userToken.User))
                return false;

            _emailSender.SendEmail(message);
            return true;
        }
    }
}
