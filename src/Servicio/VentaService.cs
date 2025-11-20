using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System.Linq;

namespace Servicio
{
    public class VentaService : ServicioBase, IVentaService
    {
        private readonly IOrdenCompraRepository _ordenCompraRepository;
        private readonly IComprobanteRepository _comprobanteRepository;
        private readonly IFacturaRepository _facturaRepository;
        private readonly ICarroCompraRepository _carroCompraRepository;
        private readonly IMapper _mapper;

        public VentaService(IOrdenCompraRepository ordenCompraRepository, IComprobanteRepository comprobanteRepository,
                            IFacturaRepository facturaRepository, ICarroCompraRepository carroCompraRepository,
                            IMapper mapper)
        {
            _ordenCompraRepository = ordenCompraRepository;
            _comprobanteRepository = comprobanteRepository;
            _facturaRepository = facturaRepository;
            _carroCompraRepository = carroCompraRepository;
            _mapper = mapper;
        }

        public void PersistObjects(TransactionObjectsDto dto)
        {
            _ordenCompraRepository.BeginTransaction();

            //Orden
            var ordenModel = ToOrdenCompraEntity(dto.Orden);
            _ordenCompraRepository.Add(ordenModel);
            _ordenCompraRepository.Save();

            //Comprobante
            var comprobanteDtoUpdated = UpdateComprobante(dto.Comprobante);
            var comprobanteModel = ToComprobanteEntity(comprobanteDtoUpdated);
            _comprobanteRepository.Add(comprobanteModel);
            _comprobanteRepository.Save();

            //Factura
            UpdateFactura(dto.Factura);
            var facturaModel = ToFacturaEntity(dto.Factura);
            _facturaRepository.Add(facturaModel);
            _facturaRepository.Save();

            //Carro
            _carroCompraRepository.Delete(dto.CarroId);
            _carroCompraRepository.Save();

            _ordenCompraRepository.Commit();
        }

        #region Private Mhetods
        private ComprobanteDto UpdateComprobante(ComprobanteDto comprobante)
        {
            var orden = _ordenCompraRepository.OrderByDescending(x => x.ID, "DetalleOrdenCompras.Producto").FirstOrDefault();
            orden.DetalleOrdenCompras.ToList().ForEach(item =>
            {
                comprobante.DetalleComprobantes.FirstOrDefault(x => x.ProductoId == item.ProductoId).CodigoBarra = item.Producto.CodigoBarra;
                comprobante.DetalleComprobantes.FirstOrDefault(x => x.ProductoId == item.ProductoId).Descripcion = item.Producto.Descripcion;
            });

            return comprobante;
        }
        
        private void UpdateFactura(FacturaDto factura)
        {
            var comprobante = _comprobanteRepository.OrderByDescending(x => x.ID).FirstOrDefault();
            factura.ComprobanteId = comprobante.ID;
        }

        private OrdenCompra ToOrdenCompraEntity(object? obj)
        {
            return _mapper.Map<OrdenCompra>(obj);
        }

        private Comprobante ToComprobanteEntity(object? obj)
        {
            return _mapper.Map<Comprobante>(obj);
        }

        private Factura ToFacturaEntity(object? obj)
        {
            return _mapper.Map<Factura>(obj);
        }
        #endregion
    }

}
