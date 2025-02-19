using IServicio.Factura.Dto;
using System.Collections.Generic;

namespace IServicio.Factura
{
    public interface IFacturaServicio
    {
        void Add(FacturaDto Dto);
        void Update(FacturaDto Dto);
        void SoftDelete(int Id);

        IEnumerable<FacturaDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<FacturaDto> GetAll();

        FacturaDto GetById(int? Id);
    }
}
