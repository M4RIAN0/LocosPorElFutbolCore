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
        public async Task<IActionResult> MarcaCreate(MarcaViewModel vm)
        {
            ResponseViewModel? response = await _service.Create(vm);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Marca Creada Correctamente";
                return RedirectToAction(nameof(MarcaIndex));
            }
            else TempData["error"] = response?.Message;

            return View(vm);
        }

        public async Task<IActionResult> MarcaUpdate(int id)
        {
            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
            {
                var vm = ToPutViewModel(response.Result);

                return View(vm);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MarcaUpdate(MarcaPutViewModel vm)
        {
            ResponseViewModel? response = await _service.Update(vm);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Marca Modificada Correctamente";
                return RedirectToAction(nameof(MarcaIndex));

            }
            else TempData["error"] = response?.Message;

            return View(vm);
        }

        public async Task<IActionResult> MarcaDelete(int id)
        {
            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
                return View(response.Result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MarcaDelete(MarcaGetViewModel vm)
        {
            ResponseViewModel? response = await _service.SoftDelete(vm.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Marca Eliminada Correctamente";
                return RedirectToAction(nameof(MarcaIndex));
            }
            else TempData["error"] = response?.Message;

            return View(vm);
        }

        #region Private Methods
        private MarcaPutViewModel ToPutViewModel(object? vm)
        {
            return _mapper.Map<MarcaPutViewModel>(vm);
        }
        #endregion
    }
}
