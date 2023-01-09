using Dominio.Repositorio.Talle;
using IServicio.Talle;
using IServicio.Talle.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Talle
{
    public class TalleServicio : ServicioBase, ITalleServicio
    {
        private readonly ITalleRepositorio _talleRepositorio;

        public TalleServicio(ITalleRepositorio talleRepositorio)
        {
            _talleRepositorio = talleRepositorio;
        }

        public void Add(TalleDto Dto)
        {
            var talle = new Dominio.Entidades.Talle
            {
                Codigo = Dto.Codigo,
                Descripcion = Dto.Descripcion,
                Numero = Dto.Numero,
                Letra = Dto.Letra
            };

            _talleRepositorio.Agregar(talle);
            _talleRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _talleRepositorio.Eliminar(Id);
            _talleRepositorio.Save();
        }

        //public IEnumerable<TalleDto> GetAll()
        //{
        //    return _talleRepositorio.ObtenerTodo()
        //         .Select(x => new TalleDto
        //         {
        //             Id = x.Id,
        //             Codigo = x.Codigo,
        //             Descripcion = x.Descripcion,
        //             Numero = x.Numero,
        //             Letra = x.Letra

        //         }).ToList();
        //}

        public IEnumerable<TalleDto> GetByFilter(string cadenaBuscar)
        {
            var numero = -1;
            int.TryParse(cadenaBuscar, out numero);

            return _talleRepositorio.ObtenerPorFlitro(x => x.Descripcion.Contains(cadenaBuscar) || x.Codigo == numero)
                 .Select(x => new TalleDto
                 {
                     Id = x.Id,
                     Codigo = x.Codigo,
                     Descripcion = x.Descripcion,
                     Numero = x.Numero,
                     Letra = x.Letra

                 }).ToList();
        }

        public TalleDto GetById(long? Id)
        {
            var talle = _talleRepositorio.ObtenerPorId(Id);

            return new TalleDto
            {
                Id = talle.Id,
                Codigo = talle.Codigo,
                Descripcion = talle.Descripcion,
                Numero = talle.Numero,
                Letra = talle.Letra
            };
        }

        public void Update(TalleDto Dto)
        {
            var talle = _talleRepositorio.ObtenerPorId(Dto.Id);

            talle.Descripcion = talle.Descripcion;
            talle.Numero = talle.Numero;
            talle.Letra = talle.Letra;

            _talleRepositorio.Modificar(talle);
            _talleRepositorio.Save();
        }
    }
}
