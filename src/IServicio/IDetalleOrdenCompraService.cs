using Dominio.Repositorio.Dtos;
using IServicio.Dtos;

namespace IServicio
{
    public interface IDetalleOrdenCompraService
    {
        void Add(DetalleOrdenCompraDto dto);
        DetalleOrdenCompraGetDto GetById(int id);
    }
}
