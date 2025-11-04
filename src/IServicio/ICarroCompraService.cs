using Dominio.Entidades;
using IServicio.Dtos;

namespace IServicio
{
    public interface ICarroCompraService
    {
        void Add(CarroCompraDto dto);
        void Update(CarroCompraPutDto dto);
        void Removeitem(int id);
        CarroCompraGetDto GetByUserId(string userid);
        CarroCompra GetLast();
        CarroCompraGetDto GetById(int? id);
    }
}
