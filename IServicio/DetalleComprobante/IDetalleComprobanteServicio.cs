using IServicio.DetalleComprobante.Dto;
using System.Collections.Generic;

namespace IServicio.DetalleComprobante
{
    public interface IDetalleComprobanteServicio
    {
        void Add(DetalleComprobanteDto Dto);
        void Update(DetalleComprobanteDto Dto);
        void Delete(long Id);

        IEnumerable<DetalleComprobanteDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<DetalleComprobanteDto> GetAll();

        DetalleComprobanteDto GetById(long? Id);
    }
}
