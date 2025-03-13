using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IPersonaClienteService
    {
        void Add(PersonaClienteDto dto);
        void Update(PersonaClientePutDto dto);
        void SoftDelete(int Id);
        IEnumerable<PersonaClienteGetDto> GetByFilter(string cadenaBuscar);
        IEnumerable<PersonaClienteGetDto> GetAll();
        PersonaClienteGetDto GetById(int? id);
    }
}
