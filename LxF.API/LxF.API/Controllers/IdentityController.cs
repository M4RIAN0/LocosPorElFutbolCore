using IServicio.Email;
using IServicio.Identity;
using IServicio.Identity.Dto;
using Lxf.Support.BuildingBlocks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _identityServicio.Register(model);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _identityServicio.Login(model);

            if (loginResponse.Usuario == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or Password is incorrect";
                return BadRequest(_response);
            }

            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssingRole")]
        public async Task<IActionResult> AssingRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccesful = await _identityServicio.AssignRole(model.Email, model.Role);
            if (!assignRoleSuccesful)
            {
                _response.IsSuccess = false;
                _response.Message = "Username is incorrect or not exist";
                return BadRequest(_response);
            }

            _response.Result = assignRoleSuccesful;
            return Ok(_response);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var tokenPassword = await _identityServicio.ForgotPassword(email);

            if (string.IsNullOrEmpty(tokenPassword.User))
                throw new ElementNotFoundException("Could not send link to email, pelase try again.");

            var callBackLink = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/ForgotPassword/IdentityController?token={tokenPassword.Token}&email={email}";

            var message = new Message() { To = email, Content = callBackLink!, Subject = "ForgotPasswordLink" };

            var sendMail = _identityServicio.SendMail(tokenPassword, message);

            if (sendMail)
            {
                _response.Result = sendMail;
                // a la hs de implementar en el view eliminar la seccion donde se pasa el token en 'response.Message '
                _response.Message = $"Password Changed request is sent on Email {tokenPassword.User}. Please Open your email and click the link, token={tokenPassword.Token}";
            }
            return Ok(_response);

        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([Required] ResetPasswordDto request)
        {
            var result = await _identityServicio.ResetPassword(request.Email, request.Token, request.Password);

            if (result.Succeeded)
            {
                _response.Message = $"Password was changed succesfully";
            }
            return Ok(_response);

        }
    }
}
