using IServicio.Identity;
using IServicio.Identity.Dto;
using Microsoft.AspNetCore.Mvc;

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
    }
}
