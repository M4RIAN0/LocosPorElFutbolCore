using IServicio.Comprobante.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.Comprobante
{
    public interface IComprobanteServicio
    {
        void Add(ComprobanteDto Dto);
        void Update(ComprobanteDto Dto);
        void Delete(long Id);

        IEnumerable<ComprobanteDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<ComprobanteDto> GetAll();

        ComprobanteDto GetById(long? Id);
    }
}
