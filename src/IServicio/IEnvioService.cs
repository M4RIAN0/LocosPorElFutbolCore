using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IEnvioService
    {
        void Add(EnvioDto dto);
        void SoftDelete(int id);
        IEnumerable<EnvioGetDto> GetByFilter(string persona);
        IEnumerable<EnvioGetDto> GetAll();
        EnvioGetDto GetById(int id);
    }
}
