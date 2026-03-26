using AutoMapper;
using Dominio.Repositorio.Dtos;
using IServicio.MercadoPago;
using IServicio.TemporalObject;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace LXF.Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaService _ventaService;
        private readonly ICarroComprasService _carroCompraService;
        private readonly IProductoService _productoService;
        private readonly IPersonaClienteService _personaClienteService;
        private readonly IProvinciaService _provinciaService;
        private readonly IMercadoPagoService _mercadoPagoService;
        private readonly ITemporalObjectService _temporalObjectService;
        private readonly IMapper _mapper;
        public VentaController(IVentaService ventaService, ICarroComprasService carroCompraService,
                               IProductoService productoService, IPersonaClienteService personaClienteService,
                               IProvinciaService provinciaService, IMercadoPagoService mercadoPagoService,
                               ITemporalObjectService temporalObjectService, IMapper mapper)
        {
            _ventaService = ventaService;
            _carroCompraService = carroCompraService;
            _productoService = productoService;
            _personaClienteService = personaClienteService;
            _provinciaService = provinciaService;
            _mercadoPagoService = mercadoPagoService;
            _temporalObjectService = temporalObjectService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var persona = await GetPersona();
            ViewBag.Direccion = persona.Direccion;
            await GetFormPopulated();
            var carro = await LoadCarroVmBasedOnLoggedInUser();
            return View(carro);
        }

        [Authorize]
        public async Task<IActionResult> Pay(OrdenCompraViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await AddProductoVm(vm);
                UpdateValues(vm);
                var odenVm = GetOrden(vm);
                var comprobanteVm = GetComprobante(vm);
                
                var objects = new List<object> { odenVm, comprobanteVm };
                var externalReferenceId = _temporalObjectService.GetUniqueReference();
                await _temporalObjectService.StoreObjectsCollectionAsync(externalReferenceId, objects);

                var initPointUrl = await _mercadoPagoService.CreatePaymentPreference(externalReferenceId, OrdenToGetDto(vm));

                return Redirect(initPointUrl);
            }
            else
            {
                var persona = await GetPersona();
                ViewBag.Direccion = persona.Direccion;
                await GetFormPopulated();
                var Carrovm = await LoadCarroVmBasedOnLoggedInUser();
                TempData["error"] = "Por favor, corrija los errores en el formulario.";
                return View("Checkout", Carrovm);
            }
        }

        public async Task<IActionResult> Success([FromQuery] PagosRetornoViewModel mpData)
        {
            if (mpData.collection_status != "approved" || string.IsNullOrEmpty(mpData.external_reference))
                return RedirectToAction("Failure", "Venta", mpData);

            var list = await _temporalObjectService.RetrieveObjectsCollectionAsync<object>(mpData.external_reference);

            _temporalObjectService.RemoveObjectsCollectionTemporal(mpData.external_reference);

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

        private async Task<ResponseViewModel?> PersistObjects(IEnumerable<object> list)
        {
            var transaction = new TransactionObjectsViewModel();

            var ordenVm = list.OfType<OrdenCompraViewModel>().FirstOrDefault();
            var comprobanteVm = list.OfType<ComprobanteViewModel>().FirstOrDefault();
            var facturaVm = list.OfType<FacturaViewModel>().FirstOrDefault();
            var envioVm = list.OfType<EnvioViewModel>().FirstOrDefault();
            var carroId = LoadCarroVmBasedOnLoggedInUser().Result.Id;

            transaction.Orden = ordenVm;
            transaction.Comprobante = comprobanteVm;
            transaction.Factura = facturaVm;
            transaction.Envio = envioVm;
            transaction.CarroId = carroId;

            return await _ventaService.PersistObjects(transaction);
        }

        private async Task<CarroComprasGetViewModel> LoadCarroVmBasedOnLoggedInUser()
        {
            var userId = User.FindFirstValue("Sub");
            var response = await _carroCompraService.GetByUserId(userId);

            if (response.IsSuccess && response.Result != null)
                return CarroToGetViewModel(response.Result);

            return new CarroComprasGetViewModel();
        }

        private async Task<PersonaClienteGetViewModel> GetPersona()
        {
            var email = User.FindFirstValue("Email");
            var response = await _personaClienteService.GetByFilter(email);

            if (response.IsSuccess)
            {
                var persona = ((IEnumerable<object>)response.Result).Select(p => PersonaToGetViewMdel(p)).FirstOrDefault();
                ViewBag.PersonaClienteId = persona.Id;
                return persona;
            }

            return new PersonaClienteGetViewModel();
        }

        private async Task GetFormPopulated()
        {
            var response = await _provinciaService.GetAll();

            if (!response.IsSuccess && response.Result == null)
                TempData["error"] = "No se pudieron cargar las provincias.";

            var provincias = ((IEnumerable<object>)response.Result).Select(p => ProvinciaToGetViewModel(p)).ToList();
            
            var localidades = provincias.SelectMany(p => p.Localidades).ToList();

            ViewData["Provincias"] = new SelectList(provincias, "Id", "Nombre");

            ViewData["Localidades"] = new SelectList(localidades, "Id", "Nombre");

            ViewBag.LocalidadesData = localidades.Select(l => new
            {
                Id = l.Id,
                Nombre = l.Nombre,
                ProvinciaId = l.ProvinciaId.ToString() // Incluimos el ID de Provincia
            }).ToList();
        }

        private OrdenCompraGetViewModel GetOrdenComprasGetViewModel(IEnumerable<object> list)
        {
            var ordenVm = list.OfType<OrdenCompraViewModel>().FirstOrDefault();
            ordenVm.Factura = list.OfType<ComprobanteViewModel>().FirstOrDefault().Factura;
            ordenVm.Envio = list.OfType<ComprobanteViewModel>().FirstOrDefault().Envio;

            return OrdenToGetViewModel(ordenVm);
        }

        private async Task AddProductoVm(OrdenCompraViewModel vm)
        {
            foreach (var item in vm.DetalleOrdenCompras)
            {
                ResponseViewModel? response = await _productoService.GetById(item.ProductoId);

                if (response.IsSuccess && response.Result != null)
                {
                    var prod = ProductoToViewMdel(response.Result);
                    item.Producto = prod;
                }
            }
        }

        private OrdenCompraViewModel GetOrden(OrdenCompraViewModel vm)
        {
            List<DetalleOrdenCompraViewModel> detalleOrdenCompras = [];

            vm.DetalleOrdenCompras.ToList().ForEach(item =>
            {
                var obj = new DetalleOrdenCompraViewModel
                {
                    Cantidad = item.Cantidad,
                    SubTotal = item.SubTotal,
                    Precio = item.Precio,
                    ProductoId = item.ProductoId
                };
                detalleOrdenCompras.Add(obj);
            });

            return new OrdenCompraViewModel
            {
                UserId = vm.UserId,
                Nombre = vm.Nombre,
                Email = vm.Email,
                Celular = vm.Celular,
                Fecha = vm.Fecha,
                Status = "Pagada",
                DetalleOrdenCompras = detalleOrdenCompras,
                Total = vm.Total,
                PersonaClienteId = vm.PersonaClienteId
            };
        }

        private ComprobanteViewModel GetComprobante(OrdenCompraViewModel vm)
        {
            List<DetalleComprobanteViewModel> detalleComprobantes = [];

            vm.DetalleOrdenCompras.ToList().ForEach(item =>
            {
                var obj = new DetalleComprobanteViewModel
                {
                    Cantidad = item.Cantidad,
                    SubTotal = item.SubTotal,
                    CodigoBarra = item.Producto.CodigoBarra, 
                    ProductoNombre = item.Producto.Nombre,
                    Precio = item.Precio,
                    ProductoId = item.ProductoId
                };
                detalleComprobantes.Add(obj);
            });

            return new ComprobanteViewModel
            {
                Fecha = vm.Fecha,
                DetalleComprobantes = detalleComprobantes,
                Total = vm.Total,
                ClienteId = vm.PersonaClienteId,
                Factura = vm.Factura,
                Envio = vm.Envio

            };
        }

        private void UpdateValues(OrdenCompraViewModel vm)
        {
            vm.Nombre = vm.Factura.Nombre;
            vm.Email = vm.Factura.Email;
            vm.Celular = vm.Factura.Celular;
            vm.Fecha = DateTime.Today.ToString("MM/dd/yyyy");

            vm.Factura.Fecha = vm.Fecha;
            vm.Factura.Total = vm.Total;
            vm.Factura.Estado = "Pagada";
            vm.Factura.TipoPago = "Tarjeta";

            vm.Envio.Monto = vm.Total;
        }

        private EnvioViewModel GetEnvio(OrdenCompraViewModel vm)
        {
            return new EnvioViewModel
            {
                Direccion = vm.Envio.Direccion,
                Celular = vm.Envio.Celular,
                Dni = vm.Envio.Dni,
                Email = vm.Envio.Email,
                Persona = vm.Envio.Persona,
                Monto = vm.Total,
                ComprobanteId = 0 // se completa post persistencia de Comprobante
            };
        }

        private CarroComprasGetViewModel CarroToGetViewModel(object? obj)
        {
            return _mapper.Map<CarroComprasGetViewModel>(obj);
        }

        private OrdenCompraGetViewModel OrdenToGetViewModel(object? obj)
        {
            return _mapper.Map<OrdenCompraGetViewModel>(obj);
        }

        private OrdenCompraViewModel OrdenToViewModel(object? obj)
        {
            return _mapper.Map<OrdenCompraViewModel>(obj);
        }

        private OrdenCompraGetDto OrdenToGetDto(object? obj)
        {
            return _mapper.Map<OrdenCompraGetDto>(obj);
        }

        private DetalleOrdenCompraDto DetalleOrdenToDto(object? obj)
        {
            return _mapper.Map<DetalleOrdenCompraDto>(obj);
        }

        private ProductoViewModel ProductoToViewMdel(object? obj)
        {
            return _mapper.Map<ProductoViewModel>(obj);
        }

        private PersonaClienteGetViewModel PersonaToGetViewMdel(object? obj)
        {
            return _mapper.Map<PersonaClienteGetViewModel>(obj);
        }

        private ProvinciaGetViewModel ProvinciaToGetViewModel(object? obj)
        {
            return _mapper.Map<ProvinciaGetViewModel>(obj);
        }

        #endregion
    }
}
