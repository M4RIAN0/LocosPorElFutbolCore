using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
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
