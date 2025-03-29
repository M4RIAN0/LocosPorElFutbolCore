using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System;

namespace Servicio
{
    public class ComprobanteService : ServicioBase, IComprobanteService
    {
        private readonly IComprobanteRepository _comprobanteRepositorio;

        public ComprobanteService(IComprobanteRepository comprobanteRepositorio)
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
    }
}
