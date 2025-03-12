using AutoMapper;
using Dominio.Entidades;
using Infraestructura;
using IServicio.Email;
using IServicio.Identity;
using IServicio.Identity.Dto;
using Lxf.Support.BuildingBlocks;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio
{
    public class IndentityService : IIdentityServicio
    {
        private readonly LxfContext _db;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public IndentityService(LxfContext db, UserManager<Usuario> userManager, RoleManager<Role> roleManager, IEmailSender emailSender, IMapper mapper)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<IdentityResult> AssignRole(string email, string roleName)
        {
            var user = _db.Usuario.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new Role() { Name = roleName }).GetAwaiter().GetResult();
                }

                var result = await _userManager.AddToRoleAsync(user, roleName);

                Dictionary<string, string> errors = [];

                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(p => errors.Add(p.Code, p.Description));

                    throw new BadRequestException(errors);
                }

                return result;
            }
            throw new ElementNotFoundException("No se encontro Usuario con el email especificado.");
        }

        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            var user = _db.Usuario.FirstOrDefault(x => x.UserName.ToLower() == loginDto.NombreUsuario);

            bool isValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (user == null || isValid == false)
            {
                Dictionary<string, string> errors = [];

                errors.Add("error", "El nombre de usuario o la contraseña son incorrectos.");

                throw new BadRequestException(errors);
            }

            UsuarioDto dto = _mapper.Map<UsuarioDto>(user);

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                Usuario = dto
            };

            return loginResponseDto;
        }

        public async Task<UsuarioDto> Register(RegisterDto registerDto)
        {
            Usuario usuario = RegisterDtoToUsuario(registerDto);

            var result = await _userManager.CreateAsync(usuario, registerDto.Password);

            if (result.Succeeded)
            {
                var userToReturn = _db.Usuario.First(x => x.UserName == registerDto.Email);

                return new()
                {
                    EMAIL = registerDto.Email,
                    ID = userToReturn.Id,
                    Nombre = userToReturn.Nombre,
                    Celular = userToReturn.PhoneNumber
                };
            }

            Dictionary<string, string> errors = [];

            result.Errors.ToList().ForEach(p => errors.Add(p.Code, p.Description));

            throw new BadRequestException(errors);
        }

        public async Task<UserToken> TokenPassword(string email)
        {
            var user = _db.Usuario.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                if (string.IsNullOrEmpty(token))
                    throw new ElementNotFoundException("No se pudo enviar el link al correo electrónico. Inténtelo de nuevo.");

                return new UserToken() { User = user.Email, Token = token };
            }

            throw new ElementNotFoundException("No se encontro Usuario con el email especificado.");
        }

        public async Task<IdentityResult> ResetPassword(string email, string token, string password)
        {
            var user = _db.Usuario.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, token, password);

                if (result.Succeeded)
                    return result;

                Dictionary<string, string> errors = [];

                result.Errors.ToList().ForEach(p => errors.Add(p.Code, p.Description));

                throw new BadRequestException(errors);
            }

            throw new ElementNotFoundException("No se encontro Usuario con el email especificado.");
        }

        public bool SendMail(UserToken userToken, Message message)
        {
            return _emailSender.SendEmail(message);
        }

        #region private methods
        private Usuario RegisterDtoToUsuario(RegisterDto dto)
        {
            return _mapper.Map<Usuario>(dto);
        }
        #endregion
    }
}