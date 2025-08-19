using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IDetalleCarroComprasService
    {
        void Add(DetalleCarroComprasDto dto);
        void Update(DetalleCarroComprasPutDto dto);
        void SoftDelete(int id);
        DetalleCarroComprasGetDto GetByProductId(int productoId, int carroComprasId);
        IEnumerable<DetalleCarroComprasGetDto> GetAll();
        DetalleCarroComprasGetDto GetById(int? id);
    }
}
