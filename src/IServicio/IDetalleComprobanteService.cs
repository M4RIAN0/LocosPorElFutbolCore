using IServicio.Dtos;

namespace IServicio
{
    public interface IDetalleComprobanteService
    {
        void Add(DetalleComprobanteDto dto);
        DetalleComprobanteGetDto GetById(int? Id);
    }
}
