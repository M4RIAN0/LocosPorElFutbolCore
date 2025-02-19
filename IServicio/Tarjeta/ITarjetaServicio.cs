using IServicio.Tarjeta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Tarjeta
{
    public interface ITarjetaServicio
    {
        void Add(TarjetaDto Dto);
        void Update(TarjetaDto Dto);
        void SoftDelete(int Id);

        IEnumerable<TarjetaDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        //IEnumerable<TarjetaDto> GetAll();

        TarjetaDto GetById(int? Id);
    }
}
