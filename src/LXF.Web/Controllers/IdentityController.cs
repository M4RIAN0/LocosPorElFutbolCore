using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LXF.Web.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityServiceApiClient _serviceApiClient;
        private readonly ITokenProvider _tokenProvider;
        private readonly IMapper _mapper;

        public IdentityController(IIdentityServiceApiClient serviceApiClient, ITokenProvider tokenProvider, IMapper mapper)
        {
            _serviceApiClient = serviceApiClient;
            _tokenProvider = tokenProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            LoginRequestViewModel vm = new();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestViewModel vm)
        {
            ResponseViewModel response = await _serviceApiClient.LoginAsync(vm);

            if (response != null && response.IsSuccess)
            {
                LoginResponseViewModel loginResponseViewModel = JsonConvert.DeserializeObject<LoginResponseViewModel>(Convert.ToString(response.Result));

                await SignInUser(loginResponseViewModel);
                _tokenProvider.SetToken(loginResponseViewModel.Token); // se crea el token
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = response?.Message;
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new (SD.RoleAdmin, SD.RoleAdmin),
                new (SD.RoleCustomer, SD.RoleCustomer)
            };

            ViewBag.RoleList = roleList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestViewModel vm)
        {
            if (ModelState.IsValid)
            {
                ResponseViewModel response = await _serviceApiClient.RegsiterAsync(vm);

                if (response != null && response.IsSuccess)
                {
                    if (string.IsNullOrWhiteSpace(vm.Role))
                        vm.Role = SD.RoleCustomer;

                    ResponseViewModel assignRole = await _serviceApiClient.AssignRoleAsync(vm);


                    if (assignRole != null && assignRole.IsSuccess)
                    {
                        TempData["success"] = response.Message;
                        return RedirectToAction(nameof(Login));
                    }
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }

            var roleList = new List<SelectListItem>()
            {
                new (SD.RoleAdmin, SD.RoleAdmin),
                new (SD.RoleCustomer, SD.RoleCustomer)
            };

            ViewBag.RoleList = roleList;

            return View(vm);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index", "Home");
        }

        #region Private Events
        private async Task SignInUser(LoginResponseViewModel model)
        {
            var handler = new JwtSecurityTokenHandler(); // manipulador de JWT

            var jwt = handler.ReadJwtToken(model.Token); // leemos el token de model

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme); // se crea almacenador de claims


            // se agregan distiontos claims a identity
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
               jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
               jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
               jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role,
              jwt.Claims.FirstOrDefault(u => u.Type == "role").Value)); // se agrega el claim para el Role asignado

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
        #endregion
    }
}
