using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IProductoService
    {
        void Add(ProductoDto dto);
        void Update(ProductoPutDto dto);
        void SoftDelete(int id);
        IEnumerable<ProductoGetDto> GetByFilter(string cadenaBuscar);
        IEnumerable<ProductoGetDto> GetAll();
        ProductoGetDto GetById(int? id);
    }
}
