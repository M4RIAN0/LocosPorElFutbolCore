using IServicio.Dtos;

namespace IServicio
{
    public interface IDetalleCarroCompraService
    {
        void Add(DetalleCarroCompraDto dto);
        void Update(DetalleCarroCompraPutDto dto);
        DetalleCarroCompraGetDto GetById(int? id);
    }
}
