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
        public async Task<IActionResult> CarroIndex()
        {
            var carro = await LoadCarroVmBasedOnLoggedInUser();

            if (carro.DetalleCarroCompras != null)
                return View(carro);

            TempData["info"] = "Debe Añadir Items al Carrito Para Crearlo.";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CarroRemoveItem(int detalleCarroComprasId)
        {
            ResponseViewModel? responseRemove = await _service.RemoveItem(detalleCarroComprasId);

            if (responseRemove.IsSuccess)
            {
                var userId = User.FindFirstValue("Sub");
                ResponseViewModel? response = await _service.GetByUserId(userId);

                if (response.IsSuccess && response.Result != null)
                {
                    TempData["success"] = "Carro Actualizado Correctamente.";

                    return RedirectToAction(nameof(CarroIndex));
                }

                TempData["success"] = "Carro Eliminado Correctamente.";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var carro = await LoadCarroVmBasedOnLoggedInUser();

            if (carro.DetalleCarroCompras != null)
                return View(carro);

            TempData["info"] = "Debe Añadir Items al Carrito Para Crearlo.";
            return RedirectToAction("Index", "Home");
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
