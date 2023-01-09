using Dominio.Repositorio.CuponDescuento;
using IServicio.CuponDescuento;
using IServicio.CuponDescuento.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.CuponDescuento
{
    public class CuponDescuentoServicio : ServicioBase, ICuponDescuentoServicio
    {
        private readonly ICuponDescuentoRepositorio _cuponDescuentoRepositorio;

        public CuponDescuentoServicio(ICuponDescuentoRepositorio cuponDescuentoRepositorio)
        {
            _cuponDescuentoRepositorio = cuponDescuentoRepositorio;
        }
        public void Add(CuponDescuentoDto Dto)
        {
            var cuponDescuento = new Dominio.Entidades.CuponDescuento
            {
                Descripcion = Dto.Descripcion,
                Porcentaje = Dto.Porcentaje,
                FechaEmision = Dto.FechaEmision,
                FechaCaducidad = Dto.FechaCaducidad,
                RowVersion = Dto.RowVersion
            };

            _cuponDescuentoRepositorio.Agregar(cuponDescuento);
            _cuponDescuentoRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _cuponDescuentoRepositorio.Eliminar(Id);
            _cuponDescuentoRepositorio.Save();
        }

        public IEnumerable<CuponDescuentoDto> GetAll()
        {
            return _cuponDescuentoRepositorio.ObtenerTodo("CuponDescuento").Select(x => new CuponDescuentoDto()
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Porcentaje = x.Porcentaje,
                FechaEmision = x.FechaEmision,
                FechaCaducidad = x.FechaEmision,
                ComprobanteId = x.Comprobante_Id,
                //ComprobanteStr = x.Comprobante,

            });
        }

        public IEnumerable<CuponDescuentoDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public CuponDescuentoDto GetById(long? Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CuponDescuentoDto Dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
