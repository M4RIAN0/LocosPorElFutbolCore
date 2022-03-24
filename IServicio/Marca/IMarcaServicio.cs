using IServicio.Marca.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Marca
{
    public interface IMarcaServicio
    {
        void Add(MarcaDto Dto);
        void Update(MarcaDto Dto);
        void Delete(long Id);

        IEnumerable<MarcaDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<MarcaDto> GetAll();

        MarcaDto GetById(long? Id);

    }
}
