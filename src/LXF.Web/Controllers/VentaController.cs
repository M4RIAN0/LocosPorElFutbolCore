using AutoMapper;
using Azure;
using Dominio.Repositorio.Dtos;
using IServicio.Dtos;
using IServicio.Email;
using IServicio.MercadoPago;
using IServicio.TemporalObject;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.Utility;
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

            if (carro.Id != 0)
            {
                return View(carro);
            }
            else
            {
                TempData["error"] = "El Carrito se Elimino. Vuelve a Crearlo";
                return RedirectToAction("Index", "Home");
            }
           
        }

        [Authorize]
        public async Task<IActionResult> Pay(OrdenCompraViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await AddProductoVm(vm);
                var odenVm = GetOrden(vm);
                var facturaVm = GetFactura(vm);
                var envioVm = GetEnvio(vm);
                var comprobanteVm = await GetComprobante(vm);
                var ordenGetDto = await GetOrdenGetDto(vm);
                var carroId = vm.CarroId;

                var objects = new List<object> { odenVm, facturaVm, envioVm, comprobanteVm, carroId };
                var externalReferenceId = _temporalObjectService.GetUniqueReference();
                await _temporalObjectService.StoreObjectsCollectionAsync(externalReferenceId, objects);

                var initPointUrl = await _mercadoPagoService.CreatePaymentPreference(externalReferenceId, ordenGetDto);

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
            
            if(list == null || !list.Any())
            {
                ViewBag.OcultarCarrito = true;
                return View("SuccessEmpty");
            }
            _temporalObjectService.RemoveObjectsCollectionTemporal(mpData.external_reference);

            var ordenGetVm = await GetOrdenComprasGetViewModel(list);

            var emailVm = new EmailVentaViewModel
            {
                Message = new Message
                {
                    To = ordenGetVm.Email,
                    Subject = "Confirmación de Pedido - LXF Deportes",
                    Content = GenerarPlantillaEmailVenta(ordenGetVm)
                },
            };

            list = list.Append(emailVm);

            var response = await PersistObjects(list);

            if (response == null || !response.IsSuccess)
                return RedirectToAction("Failure", "Venta", mpData);

            ViewBag.OcultarCarrito = true;
            return View(ordenGetVm);
        }

        public async Task<IActionResult> Failure([FromQuery] PagosRetornoViewModel mpData)
        {
            if (string.IsNullOrEmpty(mpData.collection_status) || mpData.collection_status == "null")
            {
                return RedirectToAction("Checkout");
            }

            return View();
        }

        public IActionResult ReintentarCompra()
        {
            // Seteamos el mensaje y redirigimos al Home para que el Layout lo muestre
            TempData["error"] = "El Carrito se Elimino. Vuelve a Crearlo";
            return RedirectToAction("Index", "Home");
        }

        #region private methods

        private async Task<ResponseViewModel?> PersistObjects(IEnumerable<object> list)
        {
            var transaction = new TransactionObjectsViewModel();

            var ordenVm = list.OfType<OrdenCompraViewModel>().FirstOrDefault();
            var comprobanteVm = list.OfType<ComprobanteViewModel>().FirstOrDefault();
            var facturaVm = list.OfType<FacturaViewModel>().FirstOrDefault();
            var envioVm = list.OfType<EnvioViewModel>().FirstOrDefault();
            var carroId = list.OfType<int>().FirstOrDefault();
            var email = list.OfType<EmailVentaViewModel>().FirstOrDefault();

            transaction.Orden = ordenVm;
            transaction.Comprobante = comprobanteVm;
            transaction.Factura = facturaVm;
            transaction.Envio = envioVm;
            transaction.CarroId = carroId;
            transaction.Email = email;

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

        private async Task<OrdenCompraGetViewModel> GetOrdenComprasGetViewModel(IEnumerable<object> list)
        {
            var ordenVm = list.OfType<OrdenCompraViewModel>().FirstOrDefault();
            List<DetalleOrdenCompraGetViewModel> listDetalleOrden = [];

            foreach (var item in ordenVm.DetalleOrdenCompras)
            {
                var response = await _productoService.GetByIdProductoVariante(item.ProductoVarianteId);

                listDetalleOrden.Add(new DetalleOrdenCompraGetViewModel
                {
                    Cantidad = item.Cantidad,
                    Precio = item.Precio,
                    SubTotal = item.SubTotal,
                    ProductoVarianteId = item.ProductoVarianteId,
                    ProductoVariante = ProductoVarianteToGetViewModel(response.Result)
                });
            }


            return new OrdenCompraGetViewModel
            {
                Nombre = ordenVm.Nombre,
                Celular = ordenVm.Celular,
                Total = ordenVm.Total,
                Email = ordenVm.Email,
                Fecha = ordenVm.Fecha,
                DetalleOrdenCompras = listDetalleOrden,
                Envio = EnvioToGetViewModel(list.OfType<EnvioViewModel>().FirstOrDefault()),
                Factura = FacturaToGetViewModel(list.OfType<FacturaViewModel>().FirstOrDefault())
            };
        }

        private async Task AddProductoVm(OrdenCompraViewModel vm)
        {
            foreach (var item in vm.DetalleOrdenCompras)
            {
                ResponseViewModel? response = await _productoService.GetByIdProductoVariante(item.ProductoVarianteId);

                if (response.IsSuccess && response.Result != null)
                {
                    var prod = ProductoVarianteToViewMdel(response.Result);
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
                    ProductoVarianteId = item.ProductoVarianteId
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
                Status = vm.Status,
                DetalleOrdenCompras = detalleOrdenCompras,
                Total = vm.Total,
                PersonaClienteId = vm.PersonaClienteId
            };
        }

        private async Task<ComprobanteViewModel> GetComprobante(OrdenCompraViewModel vm)
        {
            List<DetalleComprobanteViewModel> detalleComprobantes = [];

            foreach (var item in vm.DetalleOrdenCompras)
            {
                var response = await _productoService.GetById(item.Producto.ProductoId);

                if (response.IsSuccess && response.Result != null)
                {
                    var producto = ProductoToViewMdel(response.Result);

                    var obj = new DetalleComprobanteViewModel
                    {
                        Cantidad = item.Cantidad,
                        SubTotal = item.SubTotal,
                        CodigoBarra = 123,
                        ProductoNombre = producto.Nombre,
                        Talle = item.Producto.Talle,
                        Precio = item.Precio,
                        ProductoId = item.Producto.ProductoId
                    };
                    detalleComprobantes.Add(obj);
                }
            }

            return new ComprobanteViewModel
            {
                Fecha = vm.Fecha,
                DetalleComprobantes = detalleComprobantes,
                Total = vm.Total,
                ClienteId = vm.PersonaClienteId,
                FacturaId = 1, // se completa post persistencia de Factura
                EnvioId = 1 // se completa post persistencia de Envio
            };
        }

        private FacturaViewModel GetFactura(OrdenCompraViewModel vm)
        {
            return new FacturaViewModel
            {
                Nombre = vm.Factura.Nombre,
                Email = vm.Factura.Email,
                Celular = vm.Factura.Celular,
                Fecha = vm.Fecha,
                Direccion = vm.Factura.Direccion,
                Dni = vm.Factura.Dni,
                Total = vm.Total,
                Estado = vm.Factura.Estado,
                TipoPago = vm.Factura.TipoPago
            };
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
                Monto = vm.Envio.Monto,
                Estado = EnvioUtility.GetRandomState()
            };
        }

        private async Task<OrdenCompraGetDto> GetOrdenGetDto(OrdenCompraViewModel vm)
        {
            List<DetalleOrdenCompraGetDto> detalleOrdenCompras = [];

            foreach (var item in vm.DetalleOrdenCompras)
            {
                var response = await _productoService.GetByIdProductoVariante(item.ProductoVarianteId);

                if (response.IsSuccess && response.Result != null)
                {
                    var responseProducto = await _productoService.GetById(item.Producto.ProductoId);

                    if (responseProducto.IsSuccess && responseProducto.Result != null)
                    {
                        var producto = ProductoToViewMdel(responseProducto.Result);

                        var productoResumen = new ProductoResumenDto
                        {
                            Nombre = producto.Nombre,
                            Descripcion = producto.Descripcion,
                            Precio = producto.Precio,
                            ImagenUrl = producto.ImagenUrl
                        };

                        var productoVariante = ProductoVarianteToViewMdel(response.Result);
                        
                        var productoVarianteGetDto = new ProductoVarianteGetDto
                        {
                            Talle = productoVariante.Talle,
                            Stock = productoVariante.Stock,
                            CodigoBarra = productoVariante.CodigoBarra,
                            ProductoId = productoVariante.ProductoId,
                            Producto = productoResumen
                        };

                        var obj = new DetalleOrdenCompraGetDto
                        {
                            Cantidad = item.Cantidad,
                            SubTotal = item.SubTotal,
                            Precio = item.Precio,
                            ProductoVarianteId = item.ProductoVarianteId,
                            ProductoVariante = productoVarianteGetDto
                        };

                        detalleOrdenCompras.Add(obj);
                    }
                }
            }

            var ordenDto = new OrdenCompraGetDto
            {
                UserId = vm.UserId,
                Nombre = vm.Nombre,
                Email = vm.Email,
                Celular = vm.Celular,
                Fecha = vm.Fecha,
                Status = vm.Status,
                DetalleOrdenCompras = detalleOrdenCompras,
                Total = vm.Total,
                CostoEnvio = vm.Envio.Monto
            };
            return ordenDto;
        }

        private string GenerarPlantillaEmailVenta(OrdenCompraGetViewModel vm)
        {
            string baseUrl = "https://tudominio.com";

            string filasProductos = string.Empty;
            decimal subtotalCalculado = 0;

            if (vm.DetalleOrdenCompras != null)
            {
                foreach (var item in vm.DetalleOrdenCompras)
                {
                    subtotalCalculado += item.SubTotal;

                    string nombreProducto = item.ProductoVariante?.Producto?.Nombre ?? "Producto";
                    string talle = item.ProductoVariante?.Talle ?? "-";

                    filasProductos += $@"
                        <tr>
                            <td style='padding: 15px 12px 15px 0; border-bottom: 1px solid #dee2e6;'>
                                <strong style='color: #212529; font-size: 14px;'>{nombreProducto}</strong><br>
                                <span style='font-size: 12px; color: #6c757d;'>Talle: {talle}</span>
                            </td>
                            <td align='center' style='padding: 15px 12px; border-bottom: 1px solid #dee2e6; color: #495057; font-size: 14px;'>
                                ${item.Precio.ToString("N0")}
                            </td>
                            <td align='center' style='padding: 15px 12px; border-bottom: 1px solid #dee2e6; color: #495057; font-size: 14px;'>
                                {item.Cantidad}
                            </td>
                            <td align='right' style='padding: 15px 0 15px 12px; border-bottom: 1px solid #dee2e6; color: #495057; font-size: 14px; font-weight: bold;'>
                                ${(item.Precio * item.Cantidad).ToString("N0")}
                            </td>
                        </tr>";
                }
            }

            string direccionEnvio = vm.Envio != null ? vm.Envio.Direccion : "Retiro en sucursal";
            string recibeEnvio = vm.Envio != null ? vm.Envio.Persona : vm.Nombre;
            decimal costoEnvio = vm.Envio != null ? vm.Envio.Monto : 0;
            string metodoPago = vm.Factura != null ? vm.Factura.TipoPago : "A convenir";
            string dniComprador = vm.Factura != null ? vm.Factura.Dni : "-";

            return $@"
            <!DOCTYPE html>
            <html lang='es'>
            <head>
                <meta charset='UTF-8'>
            </head>
            <body style='margin: 0; padding: 0; background-color: #e9ecef; font-family: Arial, Helvetica, sans-serif; color: #212529;'>
                <table width='100%' border='0' cellspacing='0' cellpadding='0' style='background-color: #e9ecef; padding: 40px 15px;'>
                    <tr>
                        <td align='center'>
                            <!-- Contenedor Principal -->
                            <table width='600' border='0' cellspacing='0' cellpadding='0' style='background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.05);'>
                                
                                <!-- Header Oscuro -->
                                <tr>
                                    <td align='center' style='background-color: #212529; padding: 35px 20px;'>
                                        <h1 style='color: #ffffff; margin: 0; font-size: 26px; letter-spacing: 2px; text-transform: uppercase;'>LXF</h1>
                                        <p style='color: #adb5bd; margin: 8px 0 0 0; font-size: 14px;'>Confirmación de Pedido</p>
                                    </td>
                                </tr>

                                <!-- Saludo -->
                                <tr>
                                    <td style='padding: 35px 35px 20px 35px;'>
                                        <h2 style='margin: 0 0 15px 0; color: #212529; font-size: 20px;'>¡Hola, {vm.Nombre}!</h2>
                                        <p style='margin: 0; color: #495057; line-height: 1.6; font-size: 15px;'>
                                            Recibimos tu pago exitosamente el día <strong>{vm.Fecha}</strong>. Ya estamos preparando tu pedido para que lo recibas lo antes posible.
                                        </p>
                                    </td>
                                </tr>

                                <!-- Cajas de Información (Envío y Pago) -->
                                <tr>
                                    <td style='padding: 0 35px 25px 35px;'>
                                        <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                                            <tr>
                                                <td width='48%' valign='top' style='background-color: #f8f9fa; border: 1px solid #dee2e6; border-radius: 6px; padding: 15px;'>
                                                    <h3 style='margin: 0 0 10px 0; font-size: 13px; color: #6c757d; text-transform: uppercase; letter-spacing: 1px;'>Datos de Envío</h3>
                                                    <p style='margin: 0; color: #212529; font-size: 14px; line-height: 1.5;'>
                                                        <strong>{recibeEnvio}</strong><br>
                                                        {direccionEnvio}<br>
                                                    </p>
                                                </td>
                                                <td width='4%'></td>
                                                <td width='48%' valign='top' style='background-color: #f8f9fa; border: 1px solid #dee2e6; border-radius: 6px; padding: 15px;'>
                                                    <h3 style='margin: 0 0 10px 0; font-size: 13px; color: #6c757d; text-transform: uppercase; letter-spacing: 1px;'>Facturación</h3>
                                                    <p style='margin: 0; color: #212529; font-size: 14px; line-height: 1.5;'>
                                                        <strong>Método:</strong> {metodoPago}<br>
                                                        <strong>DNI:</strong> {dniComprador}
                                                    </p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <!-- Detalle de Productos -->
                                <tr>
                                    <td style='padding: 0 35px 15px 35px;'>
                                        <h3 style='margin: 0 0 10px 0; font-size: 15px; color: #212529; border-bottom: 2px solid #343a40; padding-bottom: 8px;'>Resumen de la compra</h3>
                                        <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                                            <thead>
                                                <tr>
                                                    <th align='left' style='padding: 12px 12px 12px 0; color: #6c757d; font-size: 12px; text-transform: uppercase; border-bottom: 1px solid #dee2e6;'>Artículo</th>
                                                    <th align='center' style='padding: 12px; color: #6c757d; font-size: 12px; text-transform: uppercase; border-bottom: 1px solid #dee2e6;'>Precio U.</th>
                                                    <th align='center' style='padding: 12px; color: #6c757d; font-size: 12px; text-transform: uppercase; border-bottom: 1px solid #dee2e6;'>Cant.</th>
                                                    <th align='right' style='padding: 12px 0 12px 12px; color: #6c757d; font-size: 12px; text-transform: uppercase; border-bottom: 1px solid #dee2e6;'>Subtotal</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {filasProductos}
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>

                                <!-- Totales -->
                                <tr>
                                    <td align='right' style='padding: 0 35px 35px 35px;'>
                                        <table width='250' border='0' cellspacing='0' cellpadding='0' align='right'>
                                            <tr>
                                                <td align='left' style='padding: 8px 0; color: #6c757d; font-size: 14px;'>Subtotal productos:</td>
                                                <td align='right' style='padding: 8px 0; color: #212529; font-size: 14px; font-weight: bold;'>${subtotalCalculado.ToString("N0")}</td>
                                            </tr>
                                            <tr>
                                                <td align='left' style='padding: 8px 0; color: #6c757d; font-size: 14px; border-bottom: 1px solid #dee2e6;'>Costo de envío:</td>
                                                <td align='right' style='padding: 8px 0; color: #212529; font-size: 14px; font-weight: bold; border-bottom: 1px solid #dee2e6;'>${costoEnvio.ToString("N0")}</td>
                                            </tr>
                                            <tr>
                                                <td align='left' style='padding: 15px 0 0 0; color: #212529; font-size: 16px; font-weight: bold;'>Total Abonado:</td>
                                                <td align='right' style='padding: 15px 0 0 0; color: #212529; font-size: 20px; font-weight: bold;'>${vm.Total.ToString("N0")}</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <!-- Footer Pro (Simplificado) -->
                                <tr>
                                    <td align='center' style='padding: 35px 20px; background-color: #f8f9fa; border-top: 1px solid #dee2e6;'>
                                        <!-- Info Legal y Dirección -->
                                        <p style='color: #6c757d; font-size: 12px; line-height: 1.6; margin: 0 0 15px 0;'>
                                            <strong>LXF Deportes</strong><br>
                                            Casa Central: 25 de Mayo 230, San Miguel de Tucumán.<br>
                                            © 2026 Todos los derechos reservados.
                                        </p>

                                        <!-- Disclaimer Automático -->
                                        <p style='color: #adb5bd; font-size: 11px; line-height: 1.5; margin: 0;'>
                                            Recibes este correo porque realizaste una transacción en nuestra plataforma online.<br>
                                            Por favor no respondas a este mensaje generado automáticamente.
                                        </p>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                </table>
            </body>
            </html>";
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

        private ProductoVarianteViewModel ProductoVarianteToViewMdel(object? obj)
        {
            return _mapper.Map<ProductoVarianteViewModel>(obj);
        }

        private ProductoVarianteGetDto ProductoVarianteToGetDto(object? obj)
        {
            return _mapper.Map<ProductoVarianteGetDto>(obj);
        }

        private ProductoVarianteGetViewModel ProductoVarianteToGetViewModel(object? obj)
        {
            return _mapper.Map<ProductoVarianteGetViewModel>(obj);
        }

        private PersonaClienteGetViewModel PersonaToGetViewMdel(object? obj)
        {
            return _mapper.Map<PersonaClienteGetViewModel>(obj);
        }

        private ProvinciaGetViewModel ProvinciaToGetViewModel(object? obj)
        {
            return _mapper.Map<ProvinciaGetViewModel>(obj);
        }

        private EnvioGetViewModel EnvioToGetViewModel(object? obj)
        {
            return _mapper.Map<EnvioGetViewModel>(obj);
        }

        private FacturaGetViewModel FacturaToGetViewModel(object? obj)
        {
            return _mapper.Map<FacturaGetViewModel>(obj);
        }

        #endregion
    }
}
