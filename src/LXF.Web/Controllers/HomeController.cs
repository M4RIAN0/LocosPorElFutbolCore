using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LXF.Web.Controllers;

public class HomeController : Controller
{
    private readonly IProductoService _productoService;
    private readonly ICarroComprasService _carroComprasService;
    private readonly IDetalleCarroComprasService _datalleCarroComprasService;
    private readonly IMapper _mapper;

    public HomeController(IProductoService productoService, ICarroComprasService carroComprasService, IDetalleCarroComprasService detalleCarroComprasService, IMapper mapper)
    {
        _productoService = productoService;
        _datalleCarroComprasService = detalleCarroComprasService;
        _mapper = mapper;
        _carroComprasService = carroComprasService;
    }

    public async Task<IActionResult> Index()
    {
        ResponseViewModel? response = await _productoService.GetInStockProductos();

        if (response.IsSuccess && response.Result != null)
        {
            var list = response.Result;
            return View(list);
        }
        else
        {
            TempData["error"] = response?.Message;
            return View(new List<ProductoGetViewModel>());
        }
    }

    [Authorize]
    public async Task<IActionResult> ProductoDetails(int id)
    {
        var responseProducto = await _productoService.GetById(id);

        if (responseProducto.IsSuccess && responseProducto.Result != null)
        {
            var prod = ProductoToGetViewModel(responseProducto.Result);
            var userId = User.FindFirstValue("Sub");
            var variantesAjustadas = prod.ProductosVariantes.ToList();

            var cartQuantities = new Dictionary<int, int>();
            if (!string.IsNullOrEmpty(userId))
            {
                var carro = await _carroComprasService.GetByUserId(userId);
                if (carro.IsSuccess && carro.Result != null)
                {
                    var carroGet = CarroToGetViewModel(carro.Result);
                    foreach (var item in carroGet.DetalleCarroCompras)
                    {
                        cartQuantities[item.ProductoVarianteId] = item.Cantidad;
                    }
                }
            }
            ViewBag.CartQuantities = cartQuantities;

            var prodFinal = prod;

            var responseSimil = await _productoService.GetSimilProductos(prodFinal.Id, prodFinal.CategoriaId, prodFinal.MarcaId);
            var responseInteresar = await _productoService.GetInterestingProductos(prodFinal.Id);

            if (responseSimil.IsSuccess && responseSimil.Result != null && responseInteresar.IsSuccess && responseInteresar.Result != null)
            {
                ViewBag.ProductosSimilares = responseSimil.Result;
                ViewBag.ProductosInteresar = responseInteresar.Result;
            }
            else
            {
                TempData["error"] = responseSimil.IsSuccess == false ? responseSimil.Message : responseInteresar.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(prodFinal);
        }
        else
        {
            TempData["error"] = responseProducto?.Message;
            return RedirectToAction(nameof(Index));
        }
    }

    [Authorize]
    [HttpPost]
    [ActionName("ProductoDetails")]
    public async Task<IActionResult> ProductoDetails(ProductoGetViewModel vm)
    {
        var userId = User.FindFirstValue("Sub");
        var variantId = vm.ProductosVariantes.First().Id;

        var responseProducto = await _productoService.GetById(vm.Id);
        if (!responseProducto.IsSuccess || responseProducto.Result == null)
        {
            TempData["error"] = "Error al verificar el stock.";
            return RedirectToAction(nameof(ProductoDetails), new { id = vm.Id });
        }

        var productoReal = ProductoToGetViewModel(responseProducto.Result);
        var varianteReal = productoReal.ProductosVariantes.FirstOrDefault(v => v.Id == variantId);

        if (varianteReal == null)
        {
            TempData["error"] = "Talle no encontrado.";
            return RedirectToAction(nameof(ProductoDetails), new { id = vm.Id });
        }

        var carro = await _carroComprasService.GetByUserId(userId);
        int cantidadEnCarro = 0;

        if (carro.IsSuccess && carro.Result != null)
        {
            var carroGet = CarroToGetViewModel(carro.Result);
            var itemExistente = carroGet.DetalleCarroCompras.FirstOrDefault(x => x.ProductoVarianteId == variantId);
            if (itemExistente != null)
            {
                cantidadEnCarro = itemExistente.Cantidad;
            }
        }

        if (cantidadEnCarro + vm.Cantidad > varianteReal.Stock)
        {
            TempData["error"] = "Stock Insuficiente.";

            return RedirectToAction(nameof(ProductoDetails), new { id = vm.Id });
        }

        if (carro.IsSuccess)
        {
            if (carro.Result is null)
            {
                var carroVm = HandleObjectOnCreateOrUpdate(true, userId, ProductoToPutViewModel(vm), null);
                var model = CarroToViewModel(carroVm);
                var response = await _carroComprasService.Create(model);

                return await ResponseMethod(response, vm);
            }
            else
            {
                var carroGet = CarroToGetViewModel(carro.Result);

                if (carroGet.DetalleCarroCompras.Any(x => x.ProductoVarianteId == vm.ProductosVariantes.First().Id))
                {
                    var carroPutVm = HandleObjectOnCreateOrUpdate(false, userId, ProductoToPutViewModel(vm), carroGet);
                    var modelPut = CarroToPutViewModel(carroPutVm); // convertimos el object a 'CarroComprasPutViewModel'
                    var update = await _carroComprasService.Update(modelPut);
                    return await ResponseMethod(update, vm);
                }
                else
                {
                    var carroVm = HandleObjectOnCreateOrUpdate(true, userId, ProductoToPutViewModel(vm), null);
                    var model = CarroToViewModel(carroVm); // convertimos el object a 'CarroComprasPutViewModel'
                    var detalleCarro = model.DetalleCarroCompras.First();
                    detalleCarro.CarroComprasId = carroGet.Id;
                    var modelDC = DetalleCarroToViewModel(detalleCarro);
                    var response = await _datalleCarroComprasService.Create(modelDC);

                    return await ResponseMethod(response, vm);
                }
            }
        }
        else TempData["error"] = carro?.Message;

        return View(vm);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddToCartAjax(ProductoGetViewModel vm)
    {
        var userId = User.FindFirstValue("Sub");
        var variantId = vm.ProductosVariantes.First().Id;

        var responseProducto = await _productoService.GetById(vm.Id);
        if (!responseProducto.IsSuccess || responseProducto.Result == null)
            return Json(new { success = false, message = "Error al verificar el stock." });

        var productoReal = ProductoToGetViewModel(responseProducto.Result);
        var varianteReal = productoReal.ProductosVariantes.FirstOrDefault(v => v.Id == variantId);

        if (varianteReal == null)
            return Json(new { success = false, message = "Talle no encontrado." });

        var carro = await _carroComprasService.GetByUserId(userId);
        int cantidadEnCarro = 0;

        if (carro.IsSuccess && carro.Result != null)
        {
            var carroGet = CarroToGetViewModel(carro.Result);
            var itemExistente = carroGet.DetalleCarroCompras.FirstOrDefault(x => x.ProductoVarianteId == variantId);
            if (itemExistente != null)
            {
                cantidadEnCarro = itemExistente.Cantidad;
            }
        }

        if (cantidadEnCarro + vm.Cantidad > varianteReal.Stock)
        {
            string msj = "Stock insuficiente."; 
            return Json(new { success = false, message = msj });
        }

        if (carro.IsSuccess)
        {
            // 1. SI NO EXISTE EL CARRITO, LO CREA
            if (carro.Result is null)
            {
                var carroVm = HandleObjectOnCreateOrUpdate(true, userId, ProductoToPutViewModel(vm), null);
                var model = CarroToViewModel(carroVm);
                var response = await _carroComprasService.Create(model);

                return Json(new { success = response.IsSuccess, message = response.IsSuccess ? "Item Añadido Correctamente." : response.Message });
            }
            else
            {
                var carroGet = CarroToGetViewModel(carro.Result);

                // 2. SI EXISTE Y EL PRODUCTO YA ESTÁ ADENTRO, LO ACTUALIZA
                if (carroGet.DetalleCarroCompras.Any(x => x.ProductoVarianteId == vm.ProductosVariantes.First().Id))
                {
                    var carroPutVm = HandleObjectOnCreateOrUpdate(false, userId, ProductoToPutViewModel(vm), carroGet);
                    var modelPut = CarroToPutViewModel(carroPutVm);
                    var update = await _carroComprasService.Update(modelPut);

                    return Json(new { success = update.IsSuccess, message = update.IsSuccess ? "Item Añadido Correctamente." : update.Message });
                }
                // 3. SI EXISTE PERO ES UN PRODUCTO NUEVO, LO AGREGA AL DETALLE
                else
                {
                    var carroVm = HandleObjectOnCreateOrUpdate(true, userId, ProductoToPutViewModel(vm), null);
                    var model = CarroToViewModel(carroVm);
                    var detalleCarro = model.DetalleCarroCompras.First();
                    detalleCarro.CarroComprasId = carroGet.Id;
                    var modelDC = DetalleCarroToViewModel(detalleCarro);
                    var response = await _datalleCarroComprasService.Create(modelDC);

                    return Json(new { success = response.IsSuccess, message = response.IsSuccess ? "Item Añadido Correctamente." : response.Message });
                }
            }
        }

        return Json(new { success = false, message = carro?.Message ?? "Error al procesar el carrito." });
    }

    public async Task<IActionResult> CatalogGender(string word)
    {
        ResponseViewModel? response = await _productoService.GetByFilterGenderProductos(word);
        if (response.IsSuccess && response.Result != null)
        {
            var list = response.Result;
            return View(list);
        }
        else
        {
            TempData["error"] = response?.Message;
            return View(new List<ProductoGetViewModel>());
        }
    }

    #region Private Methods
    private async Task<IActionResult> ResponseMethod(ResponseViewModel response, ProductoGetViewModel vm)
    {
        if (response.IsSuccess)
        {
            TempData["success"] = "Item Añadido Correctamente.";
            return RedirectToAction(nameof(Index));
        }
        else TempData["error"] = response?.Message;

        return RedirectToAction(nameof(ProductoDetails));
    }

    private object HandleObjectOnCreateOrUpdate(bool create, string userId, ProductoPutViewModel productoVm, CarroComprasGetViewModel? carroComprasVm)
    {
        var productoVariante = productoVm.ProductosVariantes.First();

        if (create)
        {
            return new CarroComprasViewModel()
            {
                UserId = userId,
                Total = productoVm.Cantidad * productoVm.Precio,
                LastModified = DateTime.Now,
                DetalleCarroCompras =
                [
                    new DetalleCarroComprasViewModel ()
                     {
                         ProductoVarianteId = productoVariante.Id,
                         Precio = productoVm.Precio,
                         Cantidad = productoVm.Cantidad,
                         SubTotal = productoVm.Cantidad * productoVm.Precio
                     }
                ]
            };
        }

        var model = new CarroComprasPutViewModel()
        {
            Id = carroComprasVm.Id,
            UserId = userId,
            LastModified = DateTime.Now,
            DetalleCarroCompras =
                        [
                            new()
                             {
                                 ProductoVarianteId = productoVariante.Id,
                                 Precio = productoVm.Precio,
                                 Cantidad = productoVm.Cantidad,
                                 CarroComprasId = carroComprasVm.Id
                             }
                        ]
        };

        carroComprasVm.DetalleCarroCompras.ToList().ForEach(item =>
        {
            if (model.DetalleCarroCompras.Where(x => x.ProductoVarianteId == item.ProductoVarianteId).FirstOrDefault() != null)
                model.DetalleCarroCompras.First().Id = item.Id;
        });

        return model;
    }

    private ProductoGetViewModel ProductoToGetViewModel(object? vm)
    {
        return _mapper.Map<ProductoGetViewModel>(vm);
    }
    private ProductoPutViewModel ProductoToPutViewModel(object? vm)
    {
        return _mapper.Map<ProductoPutViewModel>(vm);
    }

    private CarroComprasViewModel CarroToViewModel(object? vm)
    {
        return _mapper.Map<CarroComprasViewModel>(vm);
    }

    private CarroComprasPutViewModel CarroToPutViewModel(object? vm)
    {
        return _mapper.Map<CarroComprasPutViewModel>(vm);
    }

    private CarroComprasGetViewModel CarroToGetViewModel(object? vm)
    {
        return _mapper.Map<CarroComprasGetViewModel>(vm);
    }

    private DetalleCarroComprasViewModel DetalleCarroToViewModel(object? vm)
    {
        return _mapper.Map<DetalleCarroComprasViewModel>(vm);
    }

    #endregion
}
