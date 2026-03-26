using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var carro = await LoadCarroVmBasedOnLoggedInUser();

            if (carro.DetalleCarroCompras != null)
                return View(carro);

            TempData["info"] = "Debe Añadir Items al Carrito Para Crearlo.";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            ResponseViewModel? responseRemove = await _service.RemoveItem(id);

            if (responseRemove.IsSuccess)
            {
                var userId = User.FindFirstValue("Sub");
                ResponseViewModel? response = await _service.GetByUserId(userId);

                if (response.IsSuccess && response.Result != null)
                {
                    TempData["success"] = "Carro Actualizado Correctamente.";

                    return RedirectToAction(nameof(Index));
                }

                TempData["success"] = "Carro Eliminado Correctamente.";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> AddItem(int id)
        {
            ResponseViewModel? responseAdd = await _service.AddItem(id);

            if (responseAdd.IsSuccess)
            {
                var userId = User.FindFirstValue("Sub");
                ResponseViewModel? response = await _service.GetByUserId(userId);

                if (response.IsSuccess && response.Result != null)
                    return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> SubtractItem(int detalleCarroComprasId)
        {
            ResponseViewModel? responseSubtract = await _service.SubtractItem(detalleCarroComprasId);

            if (responseSubtract.IsSuccess)
            {
                var userId = User.FindFirstValue("Sub");
                ResponseViewModel? response = await _service.GetByUserId(userId);

                if (response.IsSuccess && response.Result != null)
                    return RedirectToAction(nameof(Index));
         
                TempData["success"] = "Carro Eliminado Correctamente.";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        #region private methods
        private async Task<CarroComprasGetViewModel> LoadCarroVmBasedOnLoggedInUser()
        {
            var userId = User.FindFirstValue("Sub");
            ResponseViewModel? response = await _service.GetByUserId(userId);

            if (response.IsSuccess && response.Result != null)
                return CarroToGetViewModel(response.Result);

            return new CarroComprasGetViewModel();
        }

        private CarroComprasGetViewModel CarroToGetViewModel(object? vm)
        {
            return _mapper.Map<CarroComprasGetViewModel>(vm);
        }

        #endregion
    }
}
