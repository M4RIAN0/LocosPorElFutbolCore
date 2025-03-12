using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface ICategoriaService
    {
        void Add(CategoriaDto dto);
        void Update(CategoriaPutDto dto);
        void SoftDelete(int id);
        IEnumerable<CategoriaGetDto> GetByFilter(string cadenaBuscar);
        IEnumerable<CategoriaGetDto> GetAll();
        CategoriaGetDto GetById(int? id);
    }
}
