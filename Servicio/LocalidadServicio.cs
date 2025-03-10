using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class LocalidadServicio : ServicioBase, ILocalidadServicio
    {
        public void Add(LocalidadDto Dto)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int Id)
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

        public LocalidadDto GetById(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Update(LocalidadDto Dto)
        {
            throw new NotImplementedException();
        }
    }
}
