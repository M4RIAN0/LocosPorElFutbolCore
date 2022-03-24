using IServicio.Movimiento.Dto;
using System.Collections.Generic;

namespace IServicio.Movimiento
{
    public interface IMovimientoServicio
    {
        void Add(MovimientoDto Dto);
        void Update(MovimientoDto Dto);
        void Delete(long Id);

        IEnumerable<MovimientoDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<MovimientoDto> GetAll();

        MovimientoDto GetById(long? Id);
    }
}
