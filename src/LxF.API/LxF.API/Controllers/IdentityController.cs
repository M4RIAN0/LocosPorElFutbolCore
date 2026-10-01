using IServicio.Dtos;
using IServicio.Email;
using IServicio.Identity;
using IServicio.Identity.Dto;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityServicio;
        protected ResponseDto _response;

        public IdentityController(IIdentityService identityServicio)
        {
            _identityServicio = identityServicio;
            _response = new();
        }

        [HttpPost("Register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterDto requestRegister)
        {
            _response.Result = await _identityServicio.Register(requestRegister);
            _response.Message = "Usuario creado correctamente.";
            return Ok(_response);
        }

        [HttpPost("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            _response.Result = await _identityServicio.Login(model);
            _response.Message = "";
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto model)
        {
            _response.Result = await _identityServicio.AssignRole(model.Email, model.Role);
            _response.Message = "Rol asignado correctamente.";
            return Ok(_response);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto request) 
        {
            var sendMail = await _identityServicio.SendMail(request.Message);

            if (!sendMail)
            {
                _response.Message = "La solicitud no pudo ser enviada.";
                return BadRequest(_response);
            }

            _response.Message = $"La solicitud de cambio de contraseña se envió por correo a {request.Email}";
            return Ok(_response);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([Required] ResetPasswordDto request)
        {
            var result = await _identityServicio.ResetPassword(request.Email, request.Token, request.Password);

            if (result.Succeeded)
            {
                _response.Message = $"La contraseña fue cambiada exitosamente.";
                return Ok(_response);
            }

            _response.Message = "Error al restablecer la contraseña.";
            return BadRequest(_response);

        }
    }
}
