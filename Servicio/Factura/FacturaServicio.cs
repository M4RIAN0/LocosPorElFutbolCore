using Dominio.Repositorio;
using IServicio.Factura;
using IServicio.Factura.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Factura
{
    public class FacturaServicio : ServicioBase, IFacturaServicio
    {
        private readonly IFacturaRepositorio _facturaRepositorio;

        public FacturaServicio(IFacturaRepositorio facturaRepositorio)
        {
            _facturaRepositorio = facturaRepositorio;
        }
        public void Add(FacturaDto Dto)
        {
            var factura = new Dominio.Entidades.Factura()
            {
                Fecha = Dto.Fecha,
                Estado = Dto.Estado,
                Total = Dto.Total
            };

            _facturaRepositorio.Add(factura);
            _facturaRepositorio.Save();
        }

        public void SoftDelete(int Id)
        {
           // _facturaRepositorio.SoftDelete(Id);
            _facturaRepositorio.Save();
        }

        public IEnumerable<FacturaDto> GetAll()
        {
            return _facturaRepositorio.GetAll("Factura").Select(x => new FacturaDto()
            {
                Id = x.ID,
                Fecha = x.Fecha,
                Total = x.Total,
                ClienteId = x.ClienteId,
                Comprobante_Id = x.ComprobanteId,
                Estado= x.Estado,
                Movimiento_Id = x.MovimientoId,
                MovimientoStr = x.Movimiento.ID.ToString(),
                
                
            }).ToList();
        }

        public IEnumerable<FacturaDto> GetByFilter(string cadenaBuscar)
        {
            return _facturaRepositorio.GetByFilter(x => x.Estado.Contains(cadenaBuscar), "Factura")
                .Select(x => new FacturaDto()
                {
                    Id = x.ID,
                    Estado = x.Estado,
                    Fecha = x.Fecha,
                    Total = x.Total,
                    ClienteId = x.ClienteId,
                    Comprobante_Id = x.ComprobanteId,
                    Movimiento_Id = x.MovimientoId,
                });
        }

        public FacturaDto GetById(int? Id)
        {
            var factura = _facturaRepositorio.GetById(Id, "Factura");

            return new FacturaDto()
            {
                Id = factura.ID,
                Estado = factura.Estado,
                Fecha = factura.Fecha,
                Total = factura.Total,
                ClienteId = factura.ClienteId,
                Comprobante_Id = factura.ComprobanteId,
                Movimiento_Id = factura.MovimientoId
            };
        }

        public void Update(FacturaDto Dto)
        {
            var factura = _facturaRepositorio.GetById(Dto.Id, "Factura");

            factura.Fecha = Dto.Fecha;
            factura.Estado = Dto.Estado;
            factura.Total = Dto.Total;
            factura.ClienteId = Dto.ClienteId;
            factura.ComprobanteId = Dto.Comprobante_Id;
            factura.MovimientoId = Dto.Movimiento_Id;

            _facturaRepositorio.Edit(factura);
            _facturaRepositorio.Save();
            
        }
    }
}
