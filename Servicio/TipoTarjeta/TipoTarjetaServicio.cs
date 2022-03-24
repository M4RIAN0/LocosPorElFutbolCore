using IServicio.TipoTarjeta;
using IServicio.TipoTarjeta.Dto;
using Servicio.Base;
using System.Collections.Generic;

namespace Servicio.TipoTarjeta
{
    public class TipoTarjetaServicio : ServicioBase, ITipoTarjetaServicio
    {
        public void Add(TipoTarjetaDto Dto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TipoTarjetaDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TipoTarjetaDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();
        }

        public TipoTarjetaDto GetById(long? Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TipoTarjetaDto Dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
