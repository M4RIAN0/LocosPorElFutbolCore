using IServicio.Localidad.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Localidad
{
    public interface ILocalidadServicio
    {
        void Add(LocalidadDto Dto);
        void Update(LocalidadDto Dto);
        void SoftDelete(int Id);

        IEnumerable<LocalidadDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<LocalidadDto> GetAll();

        LocalidadDto GetById(int? Id);
    }
}
