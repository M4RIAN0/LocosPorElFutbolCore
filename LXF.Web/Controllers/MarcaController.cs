using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace LXF.Web.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaService _service;
        private readonly IMapper _mapper;

        public MarcaController(IMarcaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> MarcaIndex()
        {
            ResponseViewModel? response = await _service.GetAll();

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            var list = response.IsSuccess ? response.Result : new List<MarcaGetViewModel>();

            return View(list);
        }

        public IActionResult MarcaCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MarcaCreate(MarcaViewModel ViewModel)
        {
            ResponseViewModel? response = await _service.Create(ViewModel);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Marca Creada Correctamente";
                return RedirectToAction(nameof(MarcaIndex));
            }
            else TempData["error"] = response?.Message;

            return View(ViewModel);
        }

        public async Task<IActionResult> MarcaUpdate(int id)
        {
            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
            {
                var ViewModel = ToPutViewModel(response.Result);

                return View(ViewModel);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MarcaUpdate(MarcaPutViewModel ViewModel)
        {
            ResponseViewModel? response = await _service.Update(ViewModel);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Marca Modificada Correctamente";
                return RedirectToAction(nameof(MarcaIndex));

            }
            else TempData["error"] = response?.Message;

            return View(ViewModel);
        }

        public async Task<IActionResult> MarcaDelete(int id)
        {
            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
                return View(response.Result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MarcaDelete(MarcaGetViewModel ViewModel)
        {
            ResponseViewModel? response = await _service.SoftDelete(ViewModel.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Marca Eliminada Correctamente";
                return RedirectToAction(nameof(MarcaIndex));
            }
            else TempData["error"] = response?.Message;

            return View(ViewModel);
        }

        #region Private Methods
        private MarcaPutViewModel ToPutViewModel(object? ViewModel)
        {
            return _mapper.Map<MarcaPutViewModel>(ViewModel);
        }
        #endregion
    }
}
