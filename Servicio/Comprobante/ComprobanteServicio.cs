using Dominio.Repositorio.Comprobante;
using IServicio.Comprobante;
using IServicio.Comprobante.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Comprobante
{
    public class ComprobanteServicio : ServicioBase, IComprobanteServicio
    {
        private readonly IComprobanteRepositorio _comprobanteRepositorio;

        public ComprobanteServicio(IComprobanteRepositorio comprobanteRepositorio)
        {
            _comprobanteRepositorio = comprobanteRepositorio;
        }
        public void Add(ComprobanteDto Dto)
        {
            var comprobante = new Dominio.Entidades.Comprobante
            {
                Fecha = Dto.Fecha,
                Total = Dto.Total,
                RowVersion = Dto.RowVersion
            };

            _comprobanteRepositorio.Agregar(comprobante);
            _comprobanteRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _comprobanteRepositorio.Eliminar(Id);
            _comprobanteRepositorio.Save();
        }

        public IEnumerable<ComprobanteDto> GetAll()
        {
            return _comprobanteRepositorio.ObtenerTodo("Comprobante").Select(x => new ComprobanteDto()
            {
                Id = x.Id,
                Fecha = x.Fecha,
                Total = x.Total
            }).ToList();
        }

        public IEnumerable<ComprobanteDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public ComprobanteDto GetById(long? Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ComprobanteDto Dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
