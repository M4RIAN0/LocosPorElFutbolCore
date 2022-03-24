using IServicio.CuponDescuento.Dto;
using System.Collections.Generic;

namespace IServicio.CuponDescuento
{
    public interface ICuponDescuentoServicio
    {
        void Add(CuponDescuentoDto Dto);
        void Update(CuponDescuentoDto Dto);
        void Delete(long Id);

        IEnumerable<CuponDescuentoDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<CuponDescuentoDto> GetAll();

        CuponDescuentoDto GetById(long? Id);
    }
}
