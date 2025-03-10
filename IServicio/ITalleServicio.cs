using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface ITalleServicio
    {
        IEnumerable<TalleDto> GetByFilter(string cadenaBuscar);

        IEnumerable<TalleDto> GetAll();

        TalleDto GetById(int? Id);
    }
}
