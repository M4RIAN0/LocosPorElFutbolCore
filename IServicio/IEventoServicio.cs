using IServicio.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio
{
    public interface IEventoServicio
    {
        void Add(EnvioDto Dto);
        void Update(EnvioDto Dto);
        void SoftDelete(int Id);

        IEnumerable<EnvioDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<EnvioDto> GetAll();

        EnvioDto GetById(int? Id);
    }
}
