using Dominio.Repositorio.Factura;
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
                Total = Dto.Total,
                Codigo = Dto.Codigo,
                RowVersion = Dto.RowVersion

            };

            _facturaRepositorio.Agregar(factura);
            _facturaRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _facturaRepositorio.Eliminar(Id);
            _facturaRepositorio.Save();
        }

        public IEnumerable<FacturaDto> GetAll()
        {
            return _facturaRepositorio.ObtenerTodo("Factura").Select(x => new FacturaDto()
            {
                Id = x.Id,
                Fecha = x.Fecha,
                Codigo = x.Codigo,
                Total = x.Total,
                ClienteId = x.ClienteId,
                Comprobante_Id = x.Comprobante_Id,
                Estado= x.Estado,
                Movimiento_Id = x.Movimiento_Id,
                MovimientoStr = x.Movimiento.Codigo.ToString(),
                
                
            }).ToList();
        }

        public IEnumerable<FacturaDto> GetByFilter(string cadenaBuscar)
        {
            return _facturaRepositorio.ObtenerPorFlitro(x => x.Estado.Contains(cadenaBuscar), "Factura")
                .Select(x => new FacturaDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Estado = x.Estado,
                    Fecha = x.Fecha,
                    Total = x.Total,
                    ClienteId = x.ClienteId,
                    Comprobante_Id = x.Comprobante_Id,
                    Movimiento_Id = x.Movimiento_Id,
                });
        }

        public FacturaDto GetById(long? Id)
        {
            var factura = _facturaRepositorio.ObtenerPorId(Id, "Factura");

            return new FacturaDto()
            {
                Id = factura.Id,
                Codigo = factura.Codigo,
                Estado = factura.Estado,
                Fecha = factura.Fecha,
                Total = factura.Total,
                ClienteId = factura.ClienteId,
                Comprobante_Id = factura.Comprobante_Id,
                Movimiento_Id = factura.Movimiento_Id,
            };
        }

        public void Update(FacturaDto Dto)
        {
            var factura = _facturaRepositorio.ObtenerPorId(Dto.Id, "Factura");

            factura.Fecha = Dto.Fecha;
            factura.Codigo = Dto.Codigo;
            factura.Estado = Dto.Estado;
            factura.Total = Dto.Total;
            factura.ClienteId = Dto.ClienteId;
            factura.Comprobante_Id = Dto.Comprobante_Id;
            factura.Movimiento_Id = Dto.Movimiento_Id;

            _facturaRepositorio.Modificar(factura);
            _facturaRepositorio.Save();
            
        }
    }
}
