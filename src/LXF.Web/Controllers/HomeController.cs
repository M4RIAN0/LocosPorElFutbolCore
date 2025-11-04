using AutoMapper;
using LXF.Web.Models;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
        ResponseViewModel? response = await _productoService.GetAll();

        if (!response.IsSuccess)
            TempData["error"] = response?.Message;

        var list = response.IsSuccess ? response.Result : new List<ProductoGetViewModel>();

        return View(list);
    }

    [Authorize]
    public async Task<IActionResult> ProductoDetails(int id)
    {
        ResponseViewModel? response = await _productoService.GetById(id);

        if (!response.IsSuccess)
            TempData["error"] = response?.Message;

        return View(response.Result);
    }

    [Authorize]
    [HttpPost]
    [ActionName("ProductoDetails")]
    public async Task<IActionResult> ProductoDetails(ProductoGetViewModel vm)
    {
        var userId = User.FindFirstValue("Sub");

        var carro = await _carroComprasService.GetByUserId(userId);

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

                if (carroGet.DetalleCarroCompras.Any(x => x.ProductoId == vm.Id))
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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

        if (create)
        {
            return new CarroComprasViewModel()
            {
                UserId = userId,
                Total = productoVm.Cantidad * productoVm.Precio,
                DetalleCarroCompras =
                [
                    new DetalleCarroComprasViewModel ()
                     {
                         ProductoId = productoVm.Id,
                         Precio = productoVm.Precio,
                         Cantidad = productoVm.Cantidad,
                         Subtotal = productoVm.Cantidad * productoVm.Precio
                     }
                ]
            };
        }

        var model = new CarroComprasPutViewModel()
        {
            Id = carroComprasVm.Id,
            UserId = userId,
            DetalleCarroCompras =
                        [
                            new()
                             {
                                 ProductoId = productoVm.Id,
                                 Precio = productoVm.Precio,
                                 Cantidad = productoVm.Cantidad,
                                 CarroComprasId = carroComprasVm.Id
                             }
                        ]
        };

        carroComprasVm.DetalleCarroCompras.ToList().ForEach(item =>
        {
            if (model.DetalleCarroCompras.Where(x => x.ProductoId == item.ProductoId).FirstOrDefault() != null)
                model.DetalleCarroCompras.First().Id = item.Id;
        });

        return model;
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
