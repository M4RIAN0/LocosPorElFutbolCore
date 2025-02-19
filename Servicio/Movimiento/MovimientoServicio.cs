using Dominio.Repositorio;
using IServicio.Movimiento;
using IServicio.Movimiento.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Movimiento
{
    public class MovimientoServicio : ServicioBase, IMovimientoServicio
    {
        private readonly IMovimientoRepositorio _movimientoRepositorio;

        public MovimientoServicio(IMovimientoRepositorio movimientoRepositorio)
        {
            _movimientoRepositorio = movimientoRepositorio;
        }

        public void Add(MovimientoDto Dto)
        {
            var facturacion = new Dominio.Entidades.Movimiento()
            {
                Fecha = Dto.Fecha,
                Tipo = Dto.Tipo,
                Monto = Dto.Monto
            };

            _movimientoRepositorio.Add(facturacion);
            _movimientoRepositorio.Save();
        }

        public void SoftDelete(int Id)
        {
           // _movimientoRepositorio.SoftDelete(Id);
            _movimientoRepositorio.Save();
        }

        //public IEnumerable<MovimientoDto> GetAll()
        //{
        //    return _movimientoRepositorio.ObtenerTodo()
        //        .Select(x => new MovimientoDto()
        //        {
        //            Id = x.ID,
        //            Codigo = x.Codigo,
        //            Fecha = x.Fecha,
        //            Tipo = x.Tipo,
        //            Monto = x.Monto

        //        }).ToList();
        //}

        public IEnumerable<MovimientoDto> GetByFilter(string cadenaBuscar)
        {
            var codigo = -1;
            int.TryParse(cadenaBuscar, out codigo);


            return _movimientoRepositorio.GetByFilter(x => x.ID == codigo)
                  .Select(x => new MovimientoDto()
                  {
                      Id = x.ID,
                      Fecha = x.Fecha,
                      Tipo = x.Tipo,
                      Monto = x.Monto

                  }).ToList();
        }

        public MovimientoDto GetById(int? Id)
        {
            var movimento = _movimientoRepositorio.GetById(Id);

            return new MovimientoDto()
            {
                Id = movimento.ID,
                Fecha = movimento.Fecha,
                Tipo = movimento.Tipo,
                Monto = movimento.Monto
            };
        }

        public void Update(MovimientoDto Dto)
        {
            var movimiento = _movimientoRepositorio.GetById(Dto.Id);

            movimiento.Fecha = Dto.Fecha;
            movimiento.Monto = Dto.Monto;

            _movimientoRepositorio.Edit(movimiento);
            _movimientoRepositorio.Save();


        }
    }
}
