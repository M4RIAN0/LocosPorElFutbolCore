using IServicio.Rubro.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Rubro
{
    public interface IRubroServicio
    {
        void Add(RubroDto Dto);
        void Update(RubroDto Dto);
        void Delete(long Id);

        IEnumerable<RubroDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<RubroDto> GetAll();

        RubroDto GetById(long? Id);
    }
}
