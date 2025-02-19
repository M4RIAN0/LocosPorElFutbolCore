using IServicio.Producto.Dto;
using System.Collections.Generic;

namespace IServicio.Producto
{
    public interface IProductoServicio
    {
        void Add(ProductoDto dto);
        void Update(ProductoPutDto dto);
        void SoftDelete(int id);

        IEnumerable<ProductoGetDto> GetByFilter(string cadenaBuscar);

        IEnumerable<ProductoGetDto> GetAll();

        ProductoGetDto GetById(int? id);
    }
}
