using IServicio.Localidad;
using IServicio.Localidad.Dto;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Localidad
{
    public class LocalidadServicio : ServicioBase, ILocalidadServicio
    {
        public void Add(LocalidadDto Dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocalidadDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocalidadDto> GetByFilter(string cadenaBuscar)
        {
            throw new NotImplementedException();
        }

        public LocalidadDto GetById(long? Id)
        {
            throw new NotImplementedException();
        }

        public void Update(LocalidadDto Dto)
        {
            throw new NotImplementedException();
        }
    }
}
