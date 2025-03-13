using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IEnvioService
    {
        void Add(EnvioDto Dto);
        void Update(EnvioDto Dto);
        void SoftDelete(int Id);
        IEnumerable<EnvioDto> GetByFilter(string cadenaBuscar);
        IEnumerable<EnvioDto> GetAll();
        EnvioDto GetById(int? Id);
    }
}
