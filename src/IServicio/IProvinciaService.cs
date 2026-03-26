using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IProvinciaService
    {
       IEnumerable<ProvinciaGetDto> GetAll();

    }
}
