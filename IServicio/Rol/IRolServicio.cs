using IServicio.Rol.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Rol
{
    public interface IRolServicio
    {
        void Add(RolDto Dto);
        void Update(RolDto Dto);
        void Delete(long Id);

        IEnumerable<RolDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<RolDto> GetAll();

        RolDto GetById(long? Id);
    }
}
