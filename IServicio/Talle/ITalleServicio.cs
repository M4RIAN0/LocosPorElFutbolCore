using IServicio.Talle.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Talle
{
    public interface ITalleServicio
    {
        void Add(TalleDto Dto);
        void Update(TalleDto Dto);
        void Delete(long Id);

        IEnumerable<TalleDto> GetByFilter(string cadenaBuscar); // obtener por filtro

       // IEnumerable<TalleDto> GetAll();

        TalleDto GetById(long? Id);
    }
}
