using IServicio.Producto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Producto
{
    public interface IProductoServicio
    {
        void Add(ProductoDto Dto);
        void Update(ProductoDto Dto);
        void Delete(long Id);

        IEnumerable<ProductoDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        //IEnumerable<ProductoDto> GetAll();

        ProductoDto GetById(long? Id);
    }
}
