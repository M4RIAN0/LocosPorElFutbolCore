using IServicio.Usuario;
using IServicio.Usuario.Dto;
using Servicio.Base;
using System.Collections.Generic;

namespace Servicio.Usuario
{
    public class UsuarioServicio : ServicioBase, IUsuarioServicio
    {
        public void Add(UsuarioDto Dto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UsuarioDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public UsuarioDto GetById(long? Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(UsuarioDto Dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
