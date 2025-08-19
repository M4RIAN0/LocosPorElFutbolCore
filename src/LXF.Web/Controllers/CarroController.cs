using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace LXF.Web.Controllers
{
    public class CarroController : Controller
    {
        private readonly ICarroComprasService _service;
        private readonly IMapper _mapper;
        public CarroController(ICarroComprasService carroComprasService, IMapper mapper)
        {
            _service = carroComprasService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CarroIndex()
        {
            var userId = User.Claims.FirstOrDefault()?.Value;

            ResponseViewModel? response = await _service.GetByUserId(userId);

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            var obj = response.IsSuccess? response.Result: new CarroComprasGetViewModel();

            return View(obj);
        }
    }
}
