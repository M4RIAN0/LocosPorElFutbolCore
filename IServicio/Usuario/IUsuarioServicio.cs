using IServicio.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Usuario
{
    public interface IUsuarioServicio
    {
        void Add(UsuarioDto Dto);
        void Update(UsuarioDto Dto);
        void Delete(long Id);

        IEnumerable<UsuarioDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<UsuarioDto> GetAll();

        UsuarioDto GetById(long? Id);
    }
}
