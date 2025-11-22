using AutoMapper;
using Dominio.Repositorio.Dtos;
using IServicio.MercadoPago;
using IServicio.TemporalObject;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LXF.Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaService _ventaService;
        private readonly ICarroComprasService _carroCompraService;
        private readonly IProductoService _productoService;
        private readonly IMercadoPagoService _mercadoPagoService;
        private readonly ITemporalObjectService _temporalObjectService;
        private readonly IMapper _mapper;
        public VentaController(IVentaService ventaService, ICarroComprasService carroCompraService, 
                               IProductoService productoService, IMercadoPagoService mercadoPagoService,
                               ITemporalObjectService temporalObjectService, IMapper mapper)
        {
            _ventaService = ventaService;
            _carroCompraService = carroCompraService;
            _productoService = productoService;
            _mercadoPagoService = mercadoPagoService;
            _temporalObjectService = temporalObjectService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var carro = await LoadCarroVmBasedOnLoggedInUser();
            return View(carro);
        }

        [Authorize]
        public async Task<IActionResult> Pay(OrdenComprasViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Fecha = DateOnly.FromDateTime(DateTime.Now).ToString();
                vm.Status = "Pagada";

                var ordenDto = await GetOrdenDto(vm);
                var facturaVm = GetFactura(vm.Total);
                var comprobanteVm = GetComprobante(vm);

                var objects = new List<object>{ordenDto, comprobanteVm, facturaVm};

                var externalReferenceId = _temporalObjectService.GetUniqueReference();
                await _temporalObjectService.StoreObjectsCollectionAsync(externalReferenceId, objects);

                var initPointUrl = await _mercadoPagoService.CreatePaymentPreference(externalReferenceId, ordenDto);

                return Redirect(initPointUrl);
            }
            else
            {
                return View("Checkout", vm);
            }
        }

        public async Task<IActionResult> Success([FromQuery] PagosRetornoViewModel mpData)
        {
            if (mpData.collection_status != "approved" || string.IsNullOrEmpty(mpData.external_reference))
                return RedirectToAction("Failure", "Venta", mpData);

            var list = await _temporalObjectService.RetrieveObjectsCollectionAsync<object>(mpData.external_reference);

            var response = await PersistObjects(list);
            if (response == null || !response.IsSuccess)
                return RedirectToAction("Failure", "Venta", mpData);

            var ordenGetVm = GetOrdenComprasGetViewModel(list);
            ViewBag.ExternalReferenceId = mpData.external_reference;

            return View(ordenGetVm);
        }

        public async Task<IActionResult> Failure([FromQuery] PagosRetornoViewModel mpData)
        {
            var list = await _temporalObjectService.RetrieveObjectsCollectionAsync<object>(mpData.external_reference);
            var ordenGetVm = GetOrdenComprasGetViewModel(list);
            ViewBag.ExternalReferenceId = mpData.external_reference;
            return View(ordenGetVm);
        }

        #region private methods
        private async Task<CarroComprasGetViewModel> LoadCarroVmBasedOnLoggedInUser()
        {
            var userId = User.FindFirstValue("Sub");
            ResponseViewModel? response = await _carroCompraService.GetByUserId(userId);

            if (response.IsSuccess && response.Result != null)
                return CarroToGetViewModel(response.Result);

            return new CarroComprasGetViewModel();
        }

        private async Task<OrdenCompraGetDto> GetOrdenDto(OrdenComprasViewModel vm)
        {
            var obj = OrdenToGetViewMdel(vm);

            foreach (var item in obj.DetalleOrdenCompras)
            {
                ResponseViewModel? response = await _productoService.GetById(item.ProductoId);

                if (response.IsSuccess && response.Result != null)
                {
                    var prod = ProductoToGetViewMdel(response.Result);
                    item.Producto = prod;
                }
            }

            return OrdenToGetDto(obj);
        }

        private ComprobanteViewModel GetComprobante(OrdenComprasViewModel vm)
        {
            List<DetalleComprobanteViewModel> detalleComprobantes = [];
            vm.DetalleOrdenCompras.ToList().ForEach(item =>
            {
                var obj = new DetalleComprobanteViewModel
                {
                    Cantidad = item.Cantidad,
                    SubTotal = item.SubTotal,
                    CodigoBarra = 1, // se completa post persistencia de Orden
                    Descripcion = "empty", // se completa post persistencia de Orden
                    Precio = item.Precio,
                    ProductoId = item.ProductoId
                };
                detalleComprobantes.Add(obj);
            });
            return new ComprobanteViewModel
            {
                Fecha = DateTime.Now.ToShortDateString(),
                DetalleComprobantes = detalleComprobantes,
                Total = vm.Total
            };
        }

        private FacturaViewModel GetFactura(decimal total)
        {
            return new FacturaViewModel
            {
                Fecha = DateTime.Now.ToShortDateString(),
                Estado = "Pagada",
                Total = total,
                TipoPago = "Tarjeta",
                ClienteId = 1,
                ComprobanteId = 1 // se completa post persistencia de Comprobante
            };
        }

        private async Task<ResponseViewModel?> PersistObjects(IEnumerable<object> list)
        {
            var transaction = new TransactionObjectsViewModel();

            var ordenVm = OrdenToViewModel(list.OfType<OrdenCompraGetDto>().FirstOrDefault());
            var comprobanteVm = list.OfType<ComprobanteViewModel>().FirstOrDefault();
            var facturaVm = list.OfType<FacturaViewModel>().FirstOrDefault();
            var carroId = LoadCarroVmBasedOnLoggedInUser().Result.Id;
           
            transaction.Orden = ordenVm;
            transaction.Comprobante = comprobanteVm;
            transaction.Factura = facturaVm;
            transaction.CarroId = carroId;

            return await _ventaService.PersistObjects(transaction);
        }

        private OrdenComprasGetViewModel GetOrdenComprasGetViewModel (IEnumerable<object> list)
        {
            return OrdenToGetViewMdel(list.OfType<OrdenCompraGetDto>().FirstOrDefault());
        }

        private CarroComprasGetViewModel CarroToGetViewModel(object? vm)
        {
            return _mapper.Map<CarroComprasGetViewModel>(vm);
        }

        private OrdenComprasGetViewModel OrdenToGetViewMdel(object? vm)
        {
            return _mapper.Map<OrdenComprasGetViewModel>(vm);
        }

        private OrdenComprasViewModel OrdenToViewModel(object? vm)
        {
            return _mapper.Map<OrdenComprasViewModel>(vm);
        }

        private OrdenCompraGetDto OrdenToGetDto(object? dto)
        {
            return _mapper.Map<OrdenCompraGetDto>(dto);
        }

        private ComprobanteGetViewModel ComprobanteToGetViewMdel(object? vm)
        {
            return _mapper.Map<ComprobanteGetViewModel>(vm);
        }

        private ProductoGetViewModel ProductoToGetViewMdel(object? vm)
        {
            return _mapper.Map<ProductoGetViewModel>(vm);
        }

        #endregion
    }
}
