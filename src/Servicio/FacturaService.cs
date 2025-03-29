using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class FacturaService : ServicioBase, IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IComprobanteRepository _comprobanteRepository;
        private readonly IDetalleComprobanteRepository _detalleComprobanteRepository;
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ITarjetaRepository _tarjetaRepository;
        private readonly IMapper _mapper;


        public FacturaService(IFacturaRepository facturaRepositorio, IComprobanteRepository comprobanteRepository,
                               IDetalleComprobanteRepository detalleComprobanteRepository, IMovimientoRepository movimientoRepository,
                               ITarjetaRepository tarjetaRepository, IMapper mapper)
        {
            _facturaRepository = facturaRepositorio;
            _comprobanteRepository = comprobanteRepository;
            _detalleComprobanteRepository = detalleComprobanteRepository;
            _movimientoRepository = movimientoRepository;
            _tarjetaRepository = tarjetaRepository;
            _mapper = mapper;
        }

        public IEnumerable<FacturaGetDto> GetAll()
        {
            return _facturaRepository.GetAll("PersonaCliente,Tarjeta")
                  .Select(p => ToGetFacturaDto(p));
        }

        public void Add(FacturaDto dto)
        {
            dto.Comprobante.DetalleComprobantes.ToList().ForEach(item => dto.Comprobante.Total += item.SubTotal);
            dto.Total = dto.Comprobante.Total;

            var _listTarjetas = _tarjetaRepository.GetByFilter(p => p.Nombre == dto.Tarjeta.Nombre &&
                                              p.NombreTitular == dto.Tarjeta.NombreTitular &&
                                              p.DniTitular == dto.Tarjeta.DniTitular &&
                                              p.BancoId == dto.Tarjeta.BancoId &&
                                              p.TipoTarjetaId == dto.Tarjeta.TipoTarjetaId);
            if (_listTarjetas.Any())
            {
                dto.Tarjeta = null;
                dto.TarjetaId = _listTarjetas.Select(p => p.ID).FirstOrDefault();
            }

            _facturaRepository.BeginTransaction();

            _facturaRepository.Add(ToEntityFacturaPost(dto));
            _facturaRepository.Save();

            var _facturaId = _facturaRepository.OrderByDescending(p => p.ID).Select(p => p.ID).FirstOrDefault();

            var _movimientoDto = new MovimientoDto
            {
                Fecha = DateOnly.FromDateTime(DateTime.Now).ToString(),
                Tipo = "Venta",
                Monto = dto.Total,
                FacturaId = _facturaId
            };

            _movimientoRepository.Add(ToEntityMovimientoPost(_movimientoDto));
            _movimientoRepository.Save();

            _facturaRepository.Commit();
        }

        public FacturaGetDto GetById(int? Id)
        {
            return ToGetFacturaDto(_facturaRepository
                   .GetById(Id, "PersonaCliente,Tarjeta"));
        }


        #region Private Mhetods
        private FacturaGetDto ToGetFacturaDto(Factura model)
        {
            return _mapper.Map<FacturaGetDto>(model);
        }

        private Factura ToEntityFacturaPost(FacturaDto dto)
        {
            return _mapper.Map<Factura>(dto);
        }

        private Movimiento ToEntityMovimientoPost(MovimientoDto dto)
        {
            return _mapper.Map<Movimiento>(dto);
        }
        #endregion
    }
}
