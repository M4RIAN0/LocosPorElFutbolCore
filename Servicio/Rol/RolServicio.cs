using IServicio.Rol;
using IServicio.Rol.Dto;
using Servicio.Base;
using System.Collections.Generic;

namespace Servicio.Rol
{
    public class RolServicio : ServicioBase, IRolServicio
    {
        public void Add(RolDto Dto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RolDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RolDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public RolDto GetById(long? Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(RolDto Dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
