using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace LXF.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _service;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ResponseViewModel? response = await _service.GetAll();

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            var list = response.IsSuccess ? response.Result : new List<CategoriaGetViewModel>();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaViewModel vm)
        {
            ResponseViewModel? response = await _service.Create(vm);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Categoria Creada Correctamente";
                return RedirectToAction(nameof(Index));
            }
            else TempData["error"] = response?.Message;

            return View(vm);
        }

        public async Task<IActionResult> Update(int id)
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
        public async Task<IActionResult> Update(CategoriaPutViewModel vm)
        {
            ResponseViewModel? response = await _service.Update(vm);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Categoria Modificada Correctamente";
                return RedirectToAction(nameof(Index));

            }
            else TempData["error"] = response?.Message;

            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
                return View(response.Result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MarcaGetViewModel vm)
        {
            ResponseViewModel? response = await _service.SoftDelete(vm.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Categoria Eliminada Correctamente";
                return RedirectToAction(nameof(Index));
            }
            else TempData["error"] = response?.Message;

            return View(vm);
        }

        #region Private Methods
        private CategoriaPutViewModel ToPutViewModel(object? vm)
        {
            return _mapper.Map<CategoriaPutViewModel>(vm);
        }
        #endregion
    }
}
