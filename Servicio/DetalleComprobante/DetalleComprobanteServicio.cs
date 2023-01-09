using Dominio.Repositorio.DetalleComprobante;
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
                Codigo = Dto.Codigo,
                CodigoBarra = Dto.CodigoBarra,
                Descripcion = Dto.Descripcion,
                Precio = Dto.Precio,

            };

            _detalleComprobanteRepositorio.Agregar(detalleComprobante);
            _detalleComprobanteRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _detalleComprobanteRepositorio.Eliminar(Id);
            _detalleComprobanteRepositorio.Save();
        }

        public IEnumerable<DetalleComprobanteDto> GetAll()
        {
            return _detalleComprobanteRepositorio.ObtenerTodo("DetalleComprobante").Select(x => new
            DetalleComprobanteDto()
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Cantidad = x.Cantidad,
                Codigo = x.Codigo,
                CodigoBarra = x.CodigoBarra,
                ComprobanteId = x.Comprobante_Id,
                Precio = x.Precio,
                ProductoId = x.Producto_Id,
                SubTotal = x.SubTotal,

            });
        }

        public IEnumerable<DetalleComprobanteDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public DetalleComprobanteDto GetById(long? Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(DetalleComprobanteDto Dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
