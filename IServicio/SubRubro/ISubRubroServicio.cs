using IServicio.SubRubro.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.SubRubro
{
    public interface ISubRubroServicio
    {
        void Add(SubRubroDto Dto);
        void Update(SubRubroDto Dto);
        void Delete(long Id);

        IEnumerable<SubRubroDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<SubRubroDto> GetAll();

        SubRubroDto GetById(long? Id);
    }
}
