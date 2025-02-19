using IServicio.Talle.Dto;
using System.Collections.Generic;

namespace IServicio.Talle
{
    public interface ITalleServicio
    {
        IEnumerable<TalleDto> GetByFilter(string cadenaBuscar);

        IEnumerable<TalleDto> GetAll();

        TalleDto GetById(int? Id);
    }
}
