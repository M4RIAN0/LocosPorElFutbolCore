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
            LoginRequestViewModel ViewModel = new();
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestViewModel ViewModel)
        {
            ResponseViewModel response = await _serviceApiClient.LoginAsync(ViewModel);

            if (response != null && response.IsSuccess)
            {
                _ = JsonConvert.DeserializeObject<LoginResponseViewModel>(Convert.ToString(response.Result));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = response?.Message;
                return View(ViewModel);
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
        public async Task<IActionResult> Register(RegisterRequestViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                ResponseViewModel response = await _serviceApiClient.RegsiterAsync(ViewModel);

                if (response != null && response.IsSuccess)
                {
                    if (string.IsNullOrWhiteSpace(ViewModel.Role))
                        ViewModel.Role = SD.RoleCustomer;

                    ResponseViewModel assignRole = await _serviceApiClient.AssignRoleAsync(ViewModel);


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

            return View(ViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            return View();
        }
    }
}
