using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IComprobanteServicio
    {
        void Add(ComprobanteDto Dto);

        IEnumerable<ComprobanteDto> GetByFilter(string cadenaBuscar);

        ComprobanteDto GetById(int? Id);
    }
}
