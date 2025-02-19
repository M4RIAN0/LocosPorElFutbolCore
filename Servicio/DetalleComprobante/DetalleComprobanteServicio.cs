using Dominio.Repositorio;
using IServicio.DetalleComprobante;
using IServicio.DetalleComprobante.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.DetalleComprobante
{
    public class DetalleComprobanteServicio : ServicioBase, IDetalleComprobanteServicio
    {
        private readonly IDetalleComprobanteRepositorio _detalleComprobanteRepositorio;

        public DetalleComprobanteServicio(IDetalleComprobanteRepositorio detalleComprobanteRepositorio)
        {
            _detalleComprobanteRepositorio = detalleComprobanteRepositorio;

        }
        public void Add(DetalleComprobanteDto Dto)
        {
            var detalleComprobante = new Dominio.Entidades.DetalleComprobante()
            {
                Cantidad = Dto.Cantidad,
                SubTotal = Dto.SubTotal,
                CodigoBarra = Dto.CodigoBarra,
                Descripcion = Dto.Descripcion,
                Precio = Dto.Precio,

            };

            _detalleComprobanteRepositorio.Add(detalleComprobante);
            _detalleComprobanteRepositorio.Save();
        }

        public void SoftDelete(int Id)
        {
            //_detalleComprobanteRepositorio.SoftDelete(Id);
            _detalleComprobanteRepositorio.Save();
        }

        public IEnumerable<DetalleComprobanteDto> GetAll()
        {
            return _detalleComprobanteRepositorio.GetAll("DetalleComprobante").Select(x => new
            DetalleComprobanteDto()
            {
                Id = x.ID,
                Descripcion = x.Descripcion,
                Cantidad = x.Cantidad,
                CodigoBarra = x.CodigoBarra,
                ComprobanteId = x.ComprobanteId,
                Precio = x.Precio,
                ProductoId = x.ProductoId,
                SubTotal = x.SubTotal,

            });
        }

        public IEnumerable<DetalleComprobanteDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public DetalleComprobanteDto GetById(int? Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(DetalleComprobanteDto Dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
