using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IFacturaService
    {
        void Add(FacturaDto dto);
        IEnumerable<FacturaGetDto> GetAll();
        FacturaGetDto GetById(int? id);
    }
}
