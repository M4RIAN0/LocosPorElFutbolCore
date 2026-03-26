using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient;
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
        private readonly IIdentityServiceApiClient _IdentityserviceApiClient;
        private readonly IPersonaClienteServiceApiClient _personaClienteServiceApiClient;
        private readonly IProvinciaService _provinciaService;
        private readonly ITokenProvider _tokenProvider;
        private readonly IMapper _mapper;

        public IdentityController(IIdentityServiceApiClient identityserviceApiClient, IPersonaClienteServiceApiClient personaClienteServiceApiClient,
                                  IProvinciaService provinciaService, ITokenProvider tokenProvider, IMapper mapper)
        {
            _IdentityserviceApiClient = identityserviceApiClient;
            _personaClienteServiceApiClient = personaClienteServiceApiClient;
            _provinciaService = provinciaService;
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
            ResponseViewModel response = await _IdentityserviceApiClient.LoginAsync(vm);

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
            return await GetFormPopulated(null);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestViewModel vm)
        {
            if (ModelState.IsValid)
            {

                var identityResponse = await _IdentityserviceApiClient.RegsiterAsync(vm);

                if (identityResponse != null && identityResponse.IsSuccess)
                {
                    vm.Role = SD.RoleCustomer;

                    var assignRole = await _IdentityserviceApiClient.AssignRoleAsync(vm);


                    if (assignRole != null && assignRole.IsSuccess)
                    {
                        TempData["success"] = identityResponse?.Message;
                    }
                    
                    var personaVM = GetPersonaVm(vm);
                    var personaResponse = await _personaClienteServiceApiClient.Add(personaVM);

                    if (personaResponse.IsSuccess)
                    {
                        TempData["success"] = identityResponse.Message;
                        return RedirectToAction(nameof(Login));
                    }
                }
                else
                {
                    TempData["error"] = identityResponse?.Message;
                }
            }

            return await GetFormPopulated(vm);
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

        private PersonaClienteViewModel GetPersonaVm(RegisterRequestViewModel vm)
        {
            string[] partesNombre = vm.Nombre.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return new  PersonaClienteViewModel {
                
                Apellido = string.Join(" ", partesNombre.Skip(1)),
                Nombre = partesNombre[0],
                Dni = vm.Dni,
                Direccion = vm.Direccion,
                Sexo = vm.Sexo,
                FechaNacimiento = vm.FechaNacimiento,
                Celular = vm.Celular,
                Email = vm.Email

            };
        }

        private async Task<IActionResult> GetFormPopulated(RegisterRequestViewModel? vm)
        {
           var response = await _provinciaService.GetAll();

           if (response.IsSuccess && response.Result != null)
            {
                var provincias = ((IEnumerable<object>)response.Result).Select(p => ToGetViewModelProvincias(p)).ToList();
                var localidades = provincias.SelectMany(p => p.Localidades).ToList();

                ViewData["Provincias"] = new SelectList(provincias, "Id", "Nombre");

                ViewData["Localidades"] = new SelectList(localidades, "Id", "Nombre");

                ViewBag.LocalidadesData = localidades.Select(l => new
                {
                    Id = l.Id,
                    Nombre = l.Nombre,
                    ProvinciaId = l.ProvinciaId.ToString() // ⬅️ Incluimos el ID de Provincia
                }).ToList();

                if (vm == null)
                    return View();

                return View(vm);
            }

           TempData["error"] = "No se pudieron cargar las provincias.";

            if (vm == null)
                return View();

            return View(vm);
        }

        private ProvinciaGetViewModel ToGetViewModelProvincias(object? obj)
        {       
            return _mapper.Map<ProvinciaGetViewModel>(obj);
        }
        #endregion
    }
}
