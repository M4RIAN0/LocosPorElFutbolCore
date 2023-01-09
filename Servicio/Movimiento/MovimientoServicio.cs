using Dominio.Repositorio.Movimiento;
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
                Codigo = Dto.Codigo,
                Fecha = Dto.Fecha,
                Tipo = Dto.Tipo,
                Monto = Dto.Monto
            };

            _movimientoRepositorio.Agregar(facturacion);
            _movimientoRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _movimientoRepositorio.Eliminar(Id);
            _movimientoRepositorio.Save();
        }

        //public IEnumerable<MovimientoDto> GetAll()
        //{
        //    return _movimientoRepositorio.ObtenerTodo()
        //        .Select(x => new MovimientoDto()
        //        {
        //            Id = x.Id,
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


            return _movimientoRepositorio.ObtenerPorFlitro(x => x.Codigo == codigo)
                  .Select(x => new MovimientoDto()
                  {
                      Id = x.Id,
                      Codigo = x.Codigo,
                      Fecha = x.Fecha,
                      Tipo = x.Tipo,
                      Monto = x.Monto

                  }).ToList();
        }

        public MovimientoDto GetById(long? Id)
        {
            var movimento = _movimientoRepositorio.ObtenerPorId(Id);

            return new MovimientoDto()
            {
                Id = movimento.Id,
                Codigo = movimento.Codigo,
                Fecha = movimento.Fecha,
                Tipo = movimento.Tipo,
                Monto = movimento.Monto
            };
        }

        public void Update(MovimientoDto Dto)
        {
            var movimiento = _movimientoRepositorio.ObtenerPorId(Dto.Id);

            movimiento.Fecha = Dto.Fecha;
            movimiento.Monto = Dto.Monto;

            _movimientoRepositorio.Modificar(movimiento);
            _movimientoRepositorio.Save();


        }
    }
}
