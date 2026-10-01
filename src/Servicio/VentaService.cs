using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using IServicio.Email;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class VentaService : ServicioBase, IVentaService
    {
        private readonly IOrdenCompraRepository _ordenCompraRepository;
        private readonly IComprobanteRepository _comprobanteRepository;
        private readonly ICarroCompraRepository _carroCompraRepository;
        private readonly IProductoVarianteRepository _productoVarianteRepository;
        private readonly IEmailSender _email;
        private readonly IMapper _mapper;

        public VentaService(IOrdenCompraRepository ordenCompraRepository, IComprobanteRepository comprobanteRepository,
                            ICarroCompraRepository carroCompraRepository, IProductoVarianteRepository productoVarianteRepository, IEmailSender email, IMapper mapper)
        {
            _ordenCompraRepository = ordenCompraRepository;
            _comprobanteRepository = comprobanteRepository;
            _carroCompraRepository = carroCompraRepository;
            _productoVarianteRepository = productoVarianteRepository;
            _email = email;
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
            UpdateComprobante(dto);
            var comprobanteModel = ToComprobanteEntity(dto.Comprobante);
            _comprobanteRepository.Add(comprobanteModel);
            _comprobanteRepository.Save();

            //Producto
            foreach (var item in dto.Orden.DetalleOrdenCompras)
            {
                var productoVariante = _productoVarianteRepository.GetById(item.ProductoVarianteId);
                productoVariante.Stock -= item.Cantidad;
                _productoVarianteRepository.Attach(productoVariante);
                _productoVarianteRepository.Save();
            }

            //Carro

            if (dto.CarroId > 0)
            {
                _carroCompraRepository.Delete(dto.CarroId);
                _carroCompraRepository.Save();
            }

            //Mail
            var email = _email.SendEmail(dto.Email.Message);

            if (!email)
            {
                _ordenCompraRepository.Rollback();
            }

            _ordenCompraRepository.Commit();
        }

        public IEnumerable<ComprobanteGetDto> GetComprobantesByClienteId(int clienteId)
        {
            return [.. _comprobanteRepository.GetByFilter(x => x.ClienteId == clienteId, "DetalleComprobantes.Producto,Envio").Select(x => ToComprobanteGetDto(x))];
        }

        public ComprobanteGetDto GetComprobantebyId(int id)
        {
            return ToComprobanteGetDto(_comprobanteRepository.GetById(id, "DetalleComprobantes.Producto,Factura,Envio"));
        }

        public bool SendVentaMail(EmailVentaDto dto)
        {
            return _email.SendEmail(dto.Message);
        }

        #region Private Mhetods
        private void UpdateComprobante(TransactionObjectsDto dto)
        {
            dto.Comprobante.Factura = dto.Factura;
            dto.Comprobante.Envio = dto.Envio;
        }
        private OrdenCompra ToOrdenCompraEntity(object? obj)
        {
            return _mapper.Map<OrdenCompra>(obj);
        }
        private Comprobante ToComprobanteEntity(object? obj)
        {
            return _mapper.Map<Comprobante>(obj);
        }
        private ComprobanteGetDto ToComprobanteGetDto(object? obj)
        {
            return _mapper.Map<ComprobanteGetDto>(obj);
        }
        #endregion
    }
}