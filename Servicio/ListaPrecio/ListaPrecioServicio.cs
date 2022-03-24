using Servicio.Base;
using IServicio.ListaPrecio;
using IServicio.ListaPrecio.Dto;
using System.Collections.Generic;
using Dominio.Repositorio.ListaPrecio;
using System.Linq;

namespace Servicio.ListaPrecio
{
    public class ListaPrecioServicio : ServicioBase, IListaPrecioServicio
    {
        private readonly IListaPrecioRepositorio _listaPrecioRepositorio;

        public ListaPrecioServicio(IListaPrecioRepositorio listaPrecioRepositorio)
        {
            _listaPrecioRepositorio = listaPrecioRepositorio;
        }

        public void Add(ListaPrecioDto Dto)
        {
            var lista = new Dominio.Entidades.ListaPrecio()
            {
                Codigo = Dto.Codigo,
                Descripcion = Dto.Descripcion,
                EstaEliminado = Dto.EstaEliminado,
                RowVersion = Dto.RowVersion,
            };
            _listaPrecioRepositorio.Agregar(lista);
            _listaPrecioRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _listaPrecioRepositorio.Eliminar(Id);
            _listaPrecioRepositorio.Save();
        }

        public IEnumerable<ListaPrecioDto> GetAll()
        {
            return _listaPrecioRepositorio.ObtenerTodo("ListaPrecio")
                 .Select(x => new ListaPrecioDto()
                 {
                     Id = x.Id,
                     Codigo = x.Codigo,
                     Descripcion = x.Descripcion,
                     EstaEliminado = x.EstaEliminado,

                 }).ToList();
        }

        public IEnumerable<ListaPrecioDto> GetByFilter(string cadenaBuscar)
        {
            return _listaPrecioRepositorio.ObtenerPorFlitro(x => x.Descripcion.Contains(cadenaBuscar), "ListaPrecio")
                .Select(x => new ListaPrecioDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    EstaEliminado = x.EstaEliminado,

                }).ToList();
        }

        public ListaPrecioDto GetById(long? Id)
        {
            var lista = _listaPrecioRepositorio.ObtenerPorId(Id, "ListaPrecio");

            return new ListaPrecioDto()
            {
                Id = lista.Id,
                Codigo = lista.Codigo,
                Descripcion = lista.Descripcion,
            };
        }

        public void Update(ListaPrecioDto Dto)
        {
            var lista = _listaPrecioRepositorio.ObtenerPorId(Dto.Id, "ListaPrecio");

            lista.Descripcion = Dto.Descripcion;
            lista.Codigo = Dto.Codigo;
            lista.EstaEliminado = Dto.EstaEliminado;

            _listaPrecioRepositorio.Modificar(lista);
            _listaPrecioRepositorio.Save();
        }
    }
}
