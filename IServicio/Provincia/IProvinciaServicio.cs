using IServicio.Provincia.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Provincia
{
    public interface IProvinciaServicio
    {
        void Add(ProvinciaDto Dto);
        void Update(ProvinciaDto Dto);
        void Delete(long Id);

        IEnumerable<ProvinciaDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<ProvinciaDto> GetAll();

        ProvinciaDto GetById(long? Id);
    }
}
