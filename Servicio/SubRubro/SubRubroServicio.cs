using Dominio.Repositorio.Subrubro;
using IServicio.SubRubro;
using IServicio.SubRubro.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.SubRubro
{
    public class SubRubroServicio : ServicioBase, ISubRubroServicio
    {
        private readonly ISubRubroRepositorio _subRubroRepositorio;

        public SubRubroServicio(ISubRubroRepositorio subRubroServicio)
        {
            _subRubroRepositorio = subRubroServicio;
        }

        public void Add(SubRubroDto Dto)
        {
            var subrubro = new Dominio.Entidades.SubRubro
            {
                Codigo = Dto.Codigo,
                Descripcion = Dto.Descripcion,
                RubroId = Dto.RubroId,
                RowVersion = Dto.RowVersion
            };

            _subRubroRepositorio.Agregar(subrubro);
            _subRubroRepositorio.Save();


        }

        public void Delete(long Id)
        {
            _subRubroRepositorio.Eliminar(Id);
            _subRubroRepositorio.Save();
        }

        public IEnumerable<SubRubroDto> GetAll()
        {
            return _subRubroRepositorio.ObtenerTodo()
                .Select(x => new SubRubroDto
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    RubroId = x.RubroId
                }).ToList();


        }

        public IEnumerable<SubRubroDto> GetByFilter(string cadenaBuscar)
        {
            var codigo = -1;
            int.TryParse(cadenaBuscar, out codigo);

            return _subRubroRepositorio.ObtenerPorFlitro(x => x.Descripcion.Contains(cadenaBuscar) || x.Codigo == codigo)
                .Select(x => new SubRubroDto
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    RubroId = x.RubroId

                }).ToList();
        }

        public SubRubroDto GetById(long? Id)
        {
            var subRubro = _subRubroRepositorio.ObtenerPorId(Id);

            return new SubRubroDto
            {
                Id = subRubro.Id,
                Codigo = subRubro.Codigo,
                Descripcion = subRubro.Descripcion,
                RubroId = subRubro.RubroId

            };
        }

        public void Update(SubRubroDto Dto)
        {
            var subRubro = _subRubroRepositorio.ObtenerPorId(Dto.Id);

            subRubro.Descripcion = subRubro.Descripcion;

            _subRubroRepositorio.Modificar(subRubro);
            _subRubroRepositorio.Save();
        }
    }
}
