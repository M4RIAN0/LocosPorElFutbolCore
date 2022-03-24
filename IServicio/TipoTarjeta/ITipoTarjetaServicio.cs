using IServicio.TipoTarjeta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.TipoTarjeta
{
    public interface ITipoTarjetaServicio
    {
        void Add(TipoTarjetaDto Dto);
        void Update(TipoTarjetaDto Dto);
        void Delete(long Id);

        IEnumerable<TipoTarjetaDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<TipoTarjetaDto> GetAll();

        TipoTarjetaDto GetById(long? Id);
    }
}
