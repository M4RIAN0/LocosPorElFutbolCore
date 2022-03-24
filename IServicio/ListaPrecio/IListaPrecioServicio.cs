using IServicio.ListaPrecio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.ListaPrecio
{
    public interface IListaPrecioServicio
    {
        void Add(ListaPrecioDto Dto);
        void Update(ListaPrecioDto Dto);
        void Delete(long Id);

        IEnumerable<ListaPrecioDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<ListaPrecioDto> GetAll();

        ListaPrecioDto GetById(long? Id);
    }
}
