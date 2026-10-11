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
        private readonly ICarroComprasService _carroService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductoController(IProductoService service, ICarroComprasService carroService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _carroService = carroService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            ResponseViewModel? response = await _service.GetAll();

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            var list = response.IsSuccess ? response.Result : new List<ProductoGetViewModel>();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            return await HandleErrorOnCreateOrUpdate(new ProductoViewModel(), true);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoViewModel vm, IFormFile? imagenArchivo)
        {
            if (imagenArchivo != null)
                vm.ImagenUrl = await HandlerAddOrUpdateImagenUrl(vm, imagenArchivo);

            ResponseViewModel? response = await _service.Create(vm);

            if (response != null && response.IsSuccess)
            {
                if (imagenArchivo != null)
                    await HandlerCrudImage(vm, imagenArchivo);

                TempData["success"] = "Producto Creado Correctamente";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = response?.Message;
            vm.ImagenUrl = null;

            return await HandleErrorOnCreateOrUpdate(vm, false);
        }

        public async Task<IActionResult> Update(int id)
        {
            var responseCart = await _carroService.GetAnyWithProductId(id);

            var result = responseCart?.Result as bool?;

            if (responseCart != null && responseCart.IsSuccess && result == true)
            {
                TempData["error"] = "No se Puede Editar el Producto Porque Está en Uno o Varios Carrito de Compras.";
                return RedirectToAction(nameof(Index));
            }

            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
            {
                return await HandleErrorOnCreateOrUpdate(ToPutViewModel(response.Result), true);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductoPutViewModel vm, IFormFile? imagenArchivo)
        {
            if (imagenArchivo != null)
                vm.ImagenUrl = await HandlerAddOrUpdateImagenUrl(vm, imagenArchivo);

            ResponseViewModel? response = await _service.Update(vm);

            if (response != null && response.IsSuccess)
            {
                if (imagenArchivo != null)
                    await HandlerCrudImage(vm, imagenArchivo);

                TempData["success"] = "Producto Modificado Correctamente";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = response?.Message;

            return await HandleErrorOnCreateOrUpdate(vm, false);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var responseCart = await _carroService.GetAnyWithProductId(id);

            var result = responseCart?.Result as bool?;

            if (responseCart != null && responseCart.IsSuccess && result == true)
            {
                TempData["error"] = "No se Puede Eliminar el Producto Porque Está en Uno o Varios Carrito de Compras.";
                return RedirectToAction(nameof(Index));
            }

            ResponseViewModel? response = await _service.GetById(id);

            if (response != null && response.IsSuccess)
                return View(response.Result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductoGetViewModel vm)
        {

            ResponseViewModel? response = await _service.SoftDelete(vm.Id);

            if (response != null && response.IsSuccess)
            {
                await HandlerCrudImage(vm, null);

                TempData["success"] = "Producto Eliminado Correctamente";
                return RedirectToAction(nameof(Index));
            }
            else TempData["error"] = response?.Message;

            return View(vm);
        }

        public async Task<IActionResult> Catalogo()
        {
            ResponseViewModel? response = await _service.GetInStockProductos();

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            var list = response.IsSuccess ? response.Result : new List<ProductoGetViewModel>();

            return View(list);
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

            if (createView)
            {
                if (IsAnyResponseFailed(responseCategorias, responseMarcas))
                    return View("Error", new ErrorViewModel { Message = "Hubo un problema al cargar los datos necesarios." });
            }

            ViewBag.Categorias = new SelectList(responseCategorias.Result as IEnumerable<CategoriaGetViewModel>, "Id", "Descripcion");
            ViewBag.Marcas = new SelectList(responseMarcas.Result as IEnumerable<MarcaGetViewModel>, "Id", "Descripcion");
            ViewBag.Talles = GetListadoTalles();
            ViewBag.Generos = GetListadoGeneros();

            if (vm != null)
                return View(vm);

            return View();
        }

        private static List<SelectListItem> GetListadoGeneros()
        {
            return new List<SelectListItem>
    {
        new SelectListItem { Value = "Hombre", Text = "Hombre" },
        new SelectListItem { Value = "Mujer", Text = "Mujer" },
        new SelectListItem { Value = "Unisex", Text = "Unisex" }
    };
        }

        private static List<object> GetListadoTalles()
        {
            var talles = new List<string>
            {
                "XS", "S", "M", "L", "XL",
                "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46"
            };

            return talles.Select(t => new
            {
                Value = t,
                Text = t,
                EsNumero = int.TryParse(t, out _)
            }).ToList<object>();
        }

        private string CLeanName(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "producto-sin-nombre";

            return nombre.Replace(" ", "-").ToLower();
        }

        private async Task HandlerCrudImage(object vm, IFormFile? image)
        {
            if ((image == null || image.Length == 0) && vm is not ProductoGetViewModel)
                return;

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string uploadsFolder = Path.Combine(wwwRootPath, @"images\Productos");

            if (vm is ProductoGetViewModel productoGetVm)
            {
                var images = Directory.GetFiles(uploadsFolder, $"Prod-Name-{CLeanName(productoGetVm.Nombre)}.*");

                foreach (var oldImage in images)
                {
                    System.IO.File.Delete(oldImage);
                }
                return;
            }

            string extension = Path.GetExtension(image.FileName);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string fileName = string.Empty;

            switch (vm)
            {
                case ProductoViewModel productoVm:

                    fileName = $"Prod-Name-{CLeanName(productoVm.Nombre)}{extension}";
                    break;

                case ProductoPutViewModel productoPutVm:

                    var oldImages = Directory.GetFiles(uploadsFolder, $"Prod-Name-{CLeanName(productoPutVm.Nombre)}.*");
                    foreach (var oldImage in oldImages)
                    {
                        System.IO.File.Delete(oldImage);
                    }

                    fileName = $"Prod-Name-{CLeanName(productoPutVm.Nombre)}{extension}";
                    break;

                default:
                    return;
            }

            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
        }

        private async Task<string> HandlerAddOrUpdateImagenUrl(object vm, IFormFile? image)
        {
            if (image == null || image.Length == 0)
                return "";

            string extension = Path.GetExtension(image.FileName);

            string fileName = string.Empty;

            switch (vm)
            {
                case ProductoViewModel productoVm:

                    fileName = $"Prod-Name-{CLeanName(productoVm.Nombre)}{extension}";
                    return $"/images/Productos/{fileName}";

                case ProductoPutViewModel productoPutVm:

                    fileName = $"Prod-Name-{CLeanName(productoPutVm.Nombre)}{extension}";
                    return $"/images/Productos/{fileName}";

                default:
                    return "";
            }
        }

        private ProductoPutViewModel ToPutViewModel(object? vm)
        {
            return _mapper.Map<ProductoPutViewModel>(vm);
        }
        #endregion
    }
}