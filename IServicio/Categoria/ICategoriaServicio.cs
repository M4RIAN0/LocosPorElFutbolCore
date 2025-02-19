using IServicio.Categoria.Dto;
using System.Collections.Generic;

namespace IServicio.Categoria
{
    public interface ICategoriaServicio
    {
        void Add(CategoriaDto dto);
        void Update(CategoriaPutDto dto);
        void SoftDelete(int id);
        IEnumerable<CategoriaGetDto> GetByFilter(string cadenaBuscar);
        IEnumerable<CategoriaGetDto> GetAll();
        CategoriaGetDto GetById(int? id);
    }
}
