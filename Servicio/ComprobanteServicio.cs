using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class ComprobanteServicio : ServicioBase, IComprobanteServicio
    {
        private readonly IComprobanteRepository _comprobanteRepositorio;

        public ComprobanteServicio(IComprobanteRepository comprobanteRepositorio)
        {
            _comprobanteRepositorio = comprobanteRepositorio;
        }
        public void Add(ComprobanteDto Dto)
        {
            var comprobante = new Dominio.Entidades.Comprobante
            {
                Fecha = DateOnly.Parse(Dto.Fecha),
                Total = Dto.Total
            };

            _comprobanteRepositorio.Add(comprobante);
            _comprobanteRepositorio.Save();
        }

        public IEnumerable<ComprobanteDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public ComprobanteDto GetById(int? Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
