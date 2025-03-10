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
        private readonly IIdentityServicio _identityServicio;
        protected ResponseDto _response;

        public IdentityController(IIdentityServicio identityServicio)
        {
            _identityServicio = identityServicio;
            _response = new();
        }

        [HttpPost("Register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            _response.Result = await _identityServicio.Register(model);
            _response.Message = "Usuario creado con éxito.";
            return Ok(_response);
        }

        [HttpPost("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            _response.Result = await _identityServicio.Login(model);
            _response.Message = "Login correcto.";
            return Ok(_response);
        }

        [HttpPost("AssingRole")]
        public async Task<IActionResult> AssingRole([FromBody] AssignRoleDto model)
        {
            _response.Result = await _identityServicio.AssignRole(model.Email, model.Role);
            _response.Message = "Rol asignado correctamente.";
            return Ok(_response);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var tokenPassword = await _identityServicio.TokenPassword(email);

            var callBackLink = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/ForgotPassword/IdentityController?token={tokenPassword.Token}&email={email}";

            var message = new Message() { To = email, Content = callBackLink!, Subject = "ForgotPasswordLink" };

            var sendMail = _identityServicio.SendMail(tokenPassword, message);

            if (!sendMail)
            {
                _response.Message = "La solicitud no pudo ser enviada.";
                return BadRequest(_response);
            }

            // a la hs de implementar en el view eliminar la seccion donde se pasa el token en 'response.Message '
            _response.Message = $"La solicitud de cambio de contraseña se envía por correo electrónico {tokenPassword.User} Abra su correo electrónico y haga clic en el link, token = {tokenPassword.Token}";
            return Ok(_response);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([Required] ResetPasswordDto request)
        {
            var result = await _identityServicio.ResetPassword(request.Email, request.Token, request.Password);

            if (result.Succeeded)
            {
                _response.Message = $"La contraseña fue cambiada exitosamente.";
            }

            return Ok(_response);

        }
    }
}
