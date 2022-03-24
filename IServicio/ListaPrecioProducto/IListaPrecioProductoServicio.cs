using IServicio.ListaPrecioProducto.Dto;
using System.Collections.Generic;

namespace IServicio.ListaPrecioProducto
{
    public interface IListaPrecioProductoServicio
    {
        void Add(ListaPrecioProductoDto Dto);
        void Update(ListaPrecioProductoDto Dto);
        void Delete(long Id);

        IEnumerable<ListaPrecioProductoDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<ListaPrecioProductoDto> GetAll();

        ListaPrecioProductoDto GetById(long? Id);
    }
}
