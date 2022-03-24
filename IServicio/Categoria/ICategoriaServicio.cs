using IServicio.Categoria.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.Categoria
{
    public interface ICategoriaServicio
    {
        void Add(CategoriaDto Dto);
        void Update(CategoriaDto Dto);
        void Delete(long Id);

        IEnumerable<CategoriaDto> GetByFilter(string cadenaBuscar); // obtener por filtro
    }
}
