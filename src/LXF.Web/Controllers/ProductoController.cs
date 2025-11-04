using AutoMapper;
using LXF.Web.Models;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LXF.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _service;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> ProductoIndex() 
        {
            ResponseViewModel? response = await _service.GetAll();

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            var list = response.IsSuccess? response.Result : new List<ProductoGetViewModel>();

            return View(list);
        }

        public async Task<IActionResult> ProductoCreate()
        {
            return await HandleErrorOnCreateOrUpdate(null, true);
        }

        [HttpPost]
        public async Task<IActionResult> ProductoCreate(ProductoViewModel vm)
        {
            ResponseViewModel? response = await _service.Create(vm);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Producto Creado Correctamente";
                return RedirectToAction(nameof(ProductoIndex));
            }
            else TempData["error"] = response?.Message;

            return await HandleErrorOnCreateOrUpdate(vm, false);
        }

        public async Task<IActionResult> ProductoUpdate(int id)
        {
            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
            {
                return await HandleErrorOnCreateOrUpdate(ToPutViewModel(response.Result), true);
            }

            return NotFound(); 
        }

        [HttpPost]
        public async Task<IActionResult> ProductoUpdate(ProductoPutViewModel vm)
        {
            ResponseViewModel? response = await _service.Update(vm);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Producto Modificado Correctamente";
                return RedirectToAction(nameof(ProductoIndex));

            }
            else TempData["error"] = response?.Message;

            return await HandleErrorOnCreateOrUpdate(vm, false);
        }

        public async Task<IActionResult> ProductoDelete(int id)
        {
            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
               return View(response.Result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductoDelete(ProductoGetViewModel vm)
        {
            ResponseViewModel? response = await _service.SoftDelete(vm.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Producto Eliminado Correctamente";
                return RedirectToAction(nameof(ProductoIndex));
            }
            else TempData["error"] = response?.Message;

            return View(vm);
        }

        #region Private Methods
        private static bool IsAnyResponseFailed(params ResponseViewModel[] responses)
        {
            return responses.Any(response => !response.IsSuccess);
        }

        private async Task<IActionResult> HandleErrorOnCreateOrUpdate(object? vm, bool createView)
        {
            var responseCategorias = await _service.GetCategorias();
            var responseMarcas = await _service.GetMarcas();
            var responseTalles = await _service.GetTalles();

            if (createView)
            {
               if (IsAnyResponseFailed(responseCategorias, responseMarcas, responseTalles))
                  return View("Error", new ErrorViewModel { Message = "Hubo un problema al cargar los datos necesarios." });
            }
               
            ViewBag.Categorias = new SelectList(responseCategorias.Result as IEnumerable<CategoriaGetViewModel>, "Id", "Descripcion");
            ViewBag.Marcas = new SelectList(responseMarcas.Result as IEnumerable<MarcaGetViewModel>, "Id", "Descripcion");
            ViewBag.Talles = new SelectList(responseTalles.Result as IEnumerable<TalleViewModel>, "Id", "Letra");


            if (vm != null)
                return View(vm);

            return View();
        }

        private ProductoPutViewModel ToPutViewModel(object? vm)
        {
            return _mapper.Map<ProductoPutViewModel>(vm);
        }
        #endregion
    }
}
