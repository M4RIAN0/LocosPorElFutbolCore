using Dominio.Entidades;
using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface ICarroComprasService
    {
        void Add(CarroComprasDto dto);
        void Update(CarroComprasPutDto dto);
        void SoftDelete(int id);
        CarroComprasGetDto GetByUserId(string userid);
        CarroCompras GetLast();
        CarroComprasGetDto GetById(int? id);
    }
}
