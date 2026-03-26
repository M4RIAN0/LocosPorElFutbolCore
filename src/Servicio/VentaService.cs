using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
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
        private readonly IMapper _mapper;

        public VentaService(IOrdenCompraRepository ordenCompraRepository, IComprobanteRepository comprobanteRepository,
                            ICarroCompraRepository carroCompraRepository, IMapper mapper)
        {
            _ordenCompraRepository = ordenCompraRepository;
            _comprobanteRepository = comprobanteRepository;
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
            var comprobanteModel = ToComprobanteEntity(dto.Comprobante);
            _comprobanteRepository.Add(comprobanteModel);
            _comprobanteRepository.Save();

            //Carro
            _carroCompraRepository.Delete(dto.CarroId);
            _carroCompraRepository.Save();

            _ordenCompraRepository.Commit();
        }

        public IEnumerable<ComprobanteGetDto> GetComprobantesByClienteId(int clienteId)
        {
            return [.. _comprobanteRepository.GetByFilter(x => x.ClienteId == clienteId, "DetalleComprobantes.Producto").Select(x => ToComprobanteGetDto(x))];
        }

        public ComprobanteGetDto GetComprobantebyId(int id)
        {
           return ToComprobanteGetDto(_comprobanteRepository.GetById(id, "Factura,Envio"));
        }

        #region Private Mhetods

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
