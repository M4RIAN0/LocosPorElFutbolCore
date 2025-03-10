using IServicio.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio
{
    public interface IBancoServicio
    {
        void Add(BancoDto Dto);
        void Update(BancoDto Dto);
        void SoftDelete(int Id);

        IEnumerable<BancoDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<BancoDto> GetAll(int id);

        IEnumerable<BancoDto> GetAll();

        BancoDto GetById(int? Id);
    }
}
