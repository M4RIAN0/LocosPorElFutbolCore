using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IFacturaService
    {
        IEnumerable<FacturaGetDto> GetAll();
        FacturaGetDto GetById(int id);
    }
}
