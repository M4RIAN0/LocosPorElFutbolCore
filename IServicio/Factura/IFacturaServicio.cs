using IServicio.Factura.Dto;
using System.Collections.Generic;

namespace IServicio.Factura
{
    public interface IFacturaServicio
    {
        void Add(FacturaDto Dto);
        void Update(FacturaDto Dto);
        void Delete(long Id);

        IEnumerable<FacturaDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<FacturaDto> GetAll();

        FacturaDto GetById(long? Id);
    }
}
