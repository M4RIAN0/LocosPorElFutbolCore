using IServicio.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio
{
    public interface IProvinciaServicio
    {
        void Add(ProvinciaDto Dto);
        void Update(ProvinciaDto Dto);
        void SoftDelete(int Id);

        IEnumerable<ProvinciaDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<ProvinciaDto> GetAll();

        ProvinciaDto GetById(int? Id);
    }
}
