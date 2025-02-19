using IServicio.PersonaCliente.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IServicio.PersonaCliente
{
    public interface IPersonaClienteServicio
    {
        void Add(PersonaClienteDto dto);
        void Update(PersonaClientePutDto dto);
        void SoftDelete(int Id);

        IEnumerable<PersonaClienteGetDto> GetByFilter(string cadenaBuscar);

        IEnumerable<PersonaClienteGetDto> GetAll();

        PersonaClienteGetDto GetById(int? id);
    }
}
