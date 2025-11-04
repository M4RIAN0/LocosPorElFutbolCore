using IServicio.Dtos;

namespace IServicio
{
    public interface IDetalleOrdenCompraService
    {
        void Add(DetalleOrdenCompraDto dto);
        void Update(DetalleOrdenCompraPutDto dto);
        DetalleOrdenCompraGetDto GetById(int? id);
    }
}
