using IServicio.Provincia;
using IServicio.Provincia.Dto;
using Servicio.Base;
using System.Collections.Generic;

namespace Servicio.Provincia
{
    public class ProvinciaServicio : ServicioBase, IProvinciaServicio
    {
        public void Add(ProvinciaDto Dto)
        {
            throw new System.NotImplementedException();
        }

        public void SoftDelete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProvinciaDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProvinciaDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public ProvinciaDto GetById(int? Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ProvinciaDto Dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
