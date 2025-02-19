using Dominio.Repositorio;
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
                Total = Dto.Total
            };

            _comprobanteRepositorio.Add(comprobante);
            _comprobanteRepositorio.Save();
        }

        public void SoftDelete(int Id)
        {
           // _comprobanteRepositorio.SoftDelete(Id);
            _comprobanteRepositorio.Save();
        }

        public IEnumerable<ComprobanteDto> GetAll()
        {
            return _comprobanteRepositorio.GetAll("Comprobante").Select(x => new ComprobanteDto()
            {
                Id = x.ID,
                Fecha = x.Fecha,
                Total = x.Total
            }).ToList();
        }

        public IEnumerable<ComprobanteDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public ComprobanteDto GetById(int? Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ComprobanteDto Dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
