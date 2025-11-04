using Dominio.Entidades;
using IServicio.Dtos;

namespace IServicio
{
    public interface IOrdenCompraService
    {
        void Add(OrdenCompraDto dto);
        OrdenCompraGetDto GetByUserId(string userid);
        OrdenCompra GetLast();
        OrdenCompraGetDto GetById(int? id);
    }
}
