using IServicio.Marca.Dto;
using System.Collections.Generic;

namespace IServicio.Marca
{
    public interface IMarcaServicio
    {
        void Add(MarcaDto dto);
        void Update(MarcaPutDto dto);
        void SoftDelete(int id);

        IEnumerable<MarcaGetDto> GetByFilter(string cadenaBuscar);

        IEnumerable<MarcaGetDto> GetAll();

        MarcaGetDto GetById(int? Id);

    }
}
