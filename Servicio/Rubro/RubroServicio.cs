using Dominio.Repositorio.Rubro;
using IServicio.Rubro;
using IServicio.Rubro.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Rubro
{
    public class RubroServicio : ServicioBase, IRubroServicio
    {
        private readonly IRubroRepositorio _rubroRepositorio;

        public RubroServicio(IRubroRepositorio rubroRepositorio)
        {
            _rubroRepositorio = rubroRepositorio;
        }

        public void Add(RubroDto Dto)
        {
            var rubro = new Dominio.Entidades.Rubro
            {
                Codigo = Dto.Codigo,
                Descripcion = Dto.Descripcion
            };

            _rubroRepositorio.Agregar(rubro);
            _rubroRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _rubroRepositorio.Eliminar(Id);
            _rubroRepositorio.Save();
        }

        //public IEnumerable<RubroDto> GetAll()
        //{
        //    return _rubroRepositorio.ObtenerTodo()
        //           .Select(x => new RubroDto
        //           {
        //               Id = x.Id,
        //               Codigo = x.Codigo,
        //               Descripcion = x.Descripcion,
        //               RowVersion = x.RowVersion

        //           }).ToList();
        //}

        public IEnumerable<RubroDto> GetByFilter(string cadenaBuscar)
        {
            var codigo = -1;
            int.TryParse(cadenaBuscar, out codigo);

            return _rubroRepositorio.ObtenerPorFlitro(x => x.Descripcion.Contains(cadenaBuscar) || x.Codigo == codigo)
                 .Select(x => new RubroDto
                 {
                     Id = x.Id,
                     Codigo = x.Codigo,
                     Descripcion = x.Descripcion,
                     RowVersion = x.RowVersion

                 }).ToList();
        }

        public RubroDto GetById(long? Id)
        {
            var rubro = _rubroRepositorio.ObtenerPorId(Id);

            return new RubroDto
            {
                Id = rubro.Id,
                Codigo = rubro.Codigo,
                Descripcion = rubro.Descripcion,
                RowVersion = rubro.RowVersion
            };
        }

        public void Update(RubroDto Dto)
        {
            var rubro = _rubroRepositorio.ObtenerPorId(Dto.Id);

            rubro.Descripcion = Dto.Descripcion;

            _rubroRepositorio.Modificar(rubro);
            _rubroRepositorio.Save();
        }
    }
}
