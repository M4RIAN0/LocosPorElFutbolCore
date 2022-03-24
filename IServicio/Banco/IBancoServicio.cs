using IServicio.Banco.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.Banco
{
    public interface IBancoServicio
    {
        void Add(BancoDto Dto);
        void Update(BancoDto Dto);
        void Delete(long Id);

        IEnumerable<BancoDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<BancoDto> GetAll(long id);

        IEnumerable<BancoDto> GetAll();

        BancoDto GetById(long? Id);
    }
}
