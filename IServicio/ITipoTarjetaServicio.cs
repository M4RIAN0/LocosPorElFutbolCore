using IServicio.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio
{
    public interface ITipoTarjetaServicio
    {
        void Add(TipoTarjetaDto Dto);
        void Update(TipoTarjetaDto Dto);
        void SoftDelete(int Id);

        IEnumerable<TipoTarjetaDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<TipoTarjetaDto> GetAll();

        TipoTarjetaDto GetById(int? Id);
    }
}
