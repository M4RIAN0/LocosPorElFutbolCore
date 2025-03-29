using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace LXF.Web.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityServiceApiClient _serviceApiClient;
        private readonly IMapper _mapper;

        public IdentityController(IIdentityServiceApiClient serviceApiClient, IMapper mapper)
        {
            _serviceApiClient = serviceApiClient;
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
                _ = JsonConvert.DeserializeObject<LoginResponseViewModel>(Convert.ToString(response.Result));

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
            return View();
        }
    }
}
