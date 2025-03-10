using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IFacturaServicio
    {
        void Add(FacturaDto dto);

        IEnumerable<FacturaGetDto> GetAll();

        FacturaGetDto GetById(int? id);
    }
}
