using IServicio.Dtos;

namespace IServicio
{
    public interface IDetalleComprobanteServicio
    {
        void Add(DetalleComprobanteDto dto);

        DetalleComprobanteGetDto GetById(int? Id);
    }
}
