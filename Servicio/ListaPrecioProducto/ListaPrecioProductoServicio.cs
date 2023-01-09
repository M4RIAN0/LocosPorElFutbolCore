using Dominio.Entidades.MetaData;
using Dominio.Repositorio.ListaPrecio;
using Dominio.Repositorio.ListaPrecioProducto;
using IServicio.ListaPrecioProducto;
using IServicio.ListaPrecioProducto.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.ListaPrecioProducto
{
    public class ListaPrecioProductoServicio : ServicioBase, IListaPrecioProductoServicio
    {
        private readonly IListaPrecioProductoRepositorio _listaPrecioProductoRepositorio;

        public ListaPrecioProductoServicio(IListaPrecioProductoRepositorio listaPrecioProductoRepositorio)
        {
            _listaPrecioProductoRepositorio = listaPrecioProductoRepositorio;
        }
        public void Add(ListaPrecioProductoDto Dto)
        {
            var listaPrecioProducto = new Dominio.Entidades.ListaPrecioProducto()
            {
                PrecioCosto = Dto.PrecioCosto,
                PrecioPublico = Dto.PrecioPublico,
                FechaActualizacion = Dto.FechaActualizacion,
                RowVersion = Dto.RowVersion,

            };

            _listaPrecioProductoRepositorio.Agregar(listaPrecioProducto);
            _listaPrecioProductoRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _listaPrecioProductoRepositorio.Eliminar(Id);
            _listaPrecioProductoRepositorio.Save();
        }

        public IEnumerable<ListaPrecioProductoDto> GetAll()
        {
            return _listaPrecioProductoRepositorio.ObtenerTodo("ListaPrecioProducto")
                 .Select(x => new ListaPrecioProductoDto()
                 {
                     Id = x.Id,
                     PrecioCosto = x.PrecioCosto,
                     PrecioPublico = x.PrecioPublico,
                     FechaActualizacion = x.FechaActualizacion,
                     ListaPrecioId = x.ListaPrecio_Id,
                     ListaPrecioStr = x.ListaPrecio.Descripcion,
                     ProductoId = x.Producto_Id,
                     ProductoStr = x.Producto.Descripcion,

                 }).ToList();
        }

        public IEnumerable<ListaPrecioProductoDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException(); //ver si se va a usar
        }

        public ListaPrecioProductoDto GetById(long? Id)
        {
            var lista = _listaPrecioProductoRepositorio.ObtenerPorId(Id, "ListaPrecioProducto");

            return new ListaPrecioProductoDto()
            {
                Id = lista.Id,
                PrecioCosto = lista.PrecioCosto,
                PrecioPublico = lista.PrecioPublico,
                FechaActualizacion = lista.FechaActualizacion,
                ProductoId = lista.Producto_Id,
                ProductoStr = lista.Producto.Descripcion,

            };
        }

        public void Update(ListaPrecioProductoDto Dto)
        {
            var lista = _listaPrecioProductoRepositorio.ObtenerPorId(Dto.Id, "ListaPrecioProducto");

            lista.PrecioCosto = Dto.PrecioCosto;
            lista.PrecioPublico = Dto.PrecioPublico;
            lista.FechaActualizacion = Dto.FechaActualizacion;

            _listaPrecioProductoRepositorio.Modificar(lista);
            _listaPrecioProductoRepositorio.Save();
        }
    }
}
