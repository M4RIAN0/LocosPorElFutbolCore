using IServicio.Persona.Dto;
using System.Collections.Generic;

namespace IServicio.Persona
{
    public interface IPersonaServicio
    {
        void Add(PersonaDto Dto);
        void Update(PersonaDto Dto);
        void Delete(long Id);

        IEnumerable<PersonaDto> GetByFilter(string cadenaBuscar); // obtener por filtro

       // IEnumerable<PersonaDto> GetAll();

        PersonaDto GetById(long? Id);
    }
}
