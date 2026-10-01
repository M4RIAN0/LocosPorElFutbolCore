using AutoMapper;
using IServicio.Email;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;
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
                    TempData["success"] = identityResponse.Message;
                    return RedirectToAction(nameof(Login));
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

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var htmlContent = GenerarPlantillaEmailResetPassword(vm.Email, "{{URL_RESETEO}}");

            vm.Message = new Message
            {
                To = vm.Email,
                Subject = "Recuperar Contraseña - LXF Deportes",
                Content = htmlContent
            };

            var response = await _IdentityserviceApiClient.ForgotPasswordAsync(vm);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = $"Se envió un mail a {vm.Email} para restablecer la contraseña.";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["error"] = "No existe un usuario registrado con ese Email.";
                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                TempData["MensajeError"] = "El enlace de recuperación es inválido o está corrupto.";
                return RedirectToAction("Login");
            }

            var model = new ResetPasswordViewModel
            {
                Token = token,
                Email = email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _IdentityserviceApiClient.ResetPasswordAsync(model);

            if (response.IsSuccess)
            {
                TempData["Success"] = "¡Tu contraseña ha sido restablecida con éxito! Ya puedes iniciar sesión.";
                return RedirectToAction("Login");
            }

            TempData["Error"] = "Hubo un error al restablecer la contraseña. Es posible que el enlace haya expirado.";
            return View(model);
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

            return new PersonaClienteViewModel
            {

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

        private string GenerarPlantillaEmailResetPassword(string email, string callBackLinkPlaceholder)
        {
            return $@"
            <!DOCTYPE html>
            <html lang='es'>
            <head><meta charset='UTF-8'></head>
            <body style='margin: 0; padding: 0; background-color: #e9ecef; font-family: Arial, sans-serif; color: #212529;'>
                <table width='100%' border='0' cellspacing='0' cellpadding='0' style='padding: 40px 15px;'>
                    <tr>
                        <td align='center'>
                            <table width='600' border='0' cellspacing='0' cellpadding='0' style='background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.05);'>
                                <tr>
                                    <td align='center' style='background-color: #212529; padding: 35px 20px;'>
                                        <h1 style='color: #ffffff; margin: 0; font-size: 26px; letter-spacing: 2px; text-transform: uppercase;'>LXF</h1>
                                        <p style='color: #adb5bd; margin: 8px 0 0 0; font-size: 14px;'>Recuperar Contraseña</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td style='padding: 35px 35px 20px 35px; text-align: center;'>
                                        <h2 style='margin: 0 0 15px 0; color: #212529; font-size: 20px;'>¿Olvidaste tu contraseña?</h2>
                                        <p style='margin: 0; color: #495057; line-height: 1.6; font-size: 15px;'>
                                            Recibimos una solicitud para restablecer la contraseña de la cuenta asociada a <strong>{email}</strong>. 
                                            Haz clic en el botón de abajo para recuperar tu acceso.
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td align='center' style='padding: 15px 35px 35px 35px;'>
                                        <a href='{callBackLinkPlaceholder}' style='background-color: #343a40; color: #ffffff; padding: 14px 28px; text-decoration: none; border-radius: 6px; font-weight: bold; font-size: 16px; display: inline-block; text-transform: uppercase; letter-spacing: 1px;'>Restablecer Contraseña</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style='padding: 0 35px 35px 35px; text-align: center; border-bottom: 1px solid #dee2e6;'>
                                        <p style='margin: 0; color: #6c757d; font-size: 13px; line-height: 1.5;'>
                                            Si no solicitaste este cambio, ignora este correo.
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td align='center' style='padding: 35px 20px; background-color: #f8f9fa;'>
                                        <p style='color: #6c757d; font-size: 12px; line-height: 1.6; margin: 0 0 15px 0;'>
                                            <strong>LXF Deportes</strong><br>
                                            Casa Central: 25 de Mayo 230, San Miguel de Tucumán.<br>
                                            © 2026 Todos los derechos reservados.
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </body>
            </html>";
        }

        private ProvinciaGetViewModel ToGetViewModelProvincias(object? obj)
        {
            return _mapper.Map<ProvinciaGetViewModel>(obj);
        }
        #endregion
    }
}
