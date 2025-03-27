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

        public async Task<IActionResult> CategoriaIndex()
        {
            ResponseViewModel? response = await _service.GetAll();

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            var list = response.IsSuccess ? response.Result : new List<CategoriaGetViewModel>();

            return View(list);
        }

        public IActionResult CategoriaCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoriaCreate(CategoriaViewModel ViewModel)
        {
            ResponseViewModel? response = await _service.Create(ViewModel);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Categoria Creada Correctamente";
                return RedirectToAction(nameof(CategoriaIndex));
            }
            else TempData["error"] = response?.Message;

            return View(ViewModel);
        }

        public async Task<IActionResult> CategoriaUpdate(int id)
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
        public async Task<IActionResult> CategoriaUpdate(CategoriaPutViewModel ViewModel)
        {
            ResponseViewModel? response = await _service.Update(ViewModel);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Categoria Modificada Correctamente";
                return RedirectToAction(nameof(CategoriaIndex));

            }
            else TempData["error"] = response?.Message;

            return View(ViewModel);
        }

        public async Task<IActionResult> CategoriaDelete(int id)
        {
            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
                return View(response.Result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CategoriaDelete(MarcaGetViewModel ViewModel)
        {
            ResponseViewModel? response = await _service.SoftDelete(ViewModel.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Categoria Eliminada Correctamente";
                return RedirectToAction(nameof(CategoriaIndex));
            }
            else TempData["error"] = response?.Message;

            return View(ViewModel);
        }

        #region Private Methods
        private CategoriaPutViewModel ToPutViewModel(object? ViewModel)
        {
            return _mapper.Map<CategoriaPutViewModel>(ViewModel);
        }
        #endregion
    }
}
