using Dominio.Repositorio.Categoria;
using IServicio.Categoria;
using IServicio.Categoria.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Categoria
{
    public class CategoriaServicio : ServicioBase, ICategoriaServicio
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServicio(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }
        public void Add(CategoriaDto Dto)
        {
            var categoria = new Dominio.Entidades.Categoria
            {
                Descripcion = Dto.Descripcion,
                RowVersion = Dto.RowVersion
            };
            _categoriaRepositorio.Agregar(categoria);
            _categoriaRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _categoriaRepositorio.Eliminar(Id);
            _categoriaRepositorio.Save();
        }

        public IEnumerable<CategoriaDto> GetByFilter(string cadenaBuscar)
        {
            return _categoriaRepositorio.ObtenerPorFlitro(x => x.Descripcion.Contains(cadenaBuscar))
                .Select(x => new CategoriaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    RowVersion = x.RowVersion
                }).ToList();
        }

        public CategoriaDto GetById(long? Id)
        {
            var categoria = _categoriaRepositorio.ObtenerPorId(Id);
            return new CategoriaDto
            {
                Id = categoria.Id,
                Descripcion = categoria.Descripcion,
                RowVersion = categoria.RowVersion
            };
        }

        public void Update(CategoriaDto Dto)
        {
            var categoria = _categoriaRepositorio.ObtenerPorId(Dto.Id);

            categoria.Descripcion = Dto.Descripcion;

            _categoriaRepositorio.Modificar(categoria);
            _categoriaRepositorio.Save();

        }
    }
}
