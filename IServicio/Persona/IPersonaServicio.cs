using IServicio.Persona.Dto;
using System.Collections.Generic;

namespace IServicio.Persona
{
    public interface IPersonaServicio
    {
        void Add(PersonaDto dto);
        void Update(PersonaDto dto);
        void SoftDelete(int id);
        IEnumerable<PersonaDto> GetByFilter(string cadenaBuscar); 
        IEnumerable<PersonaDto> GetAll();
        PersonaDto GetById(int? id);
    }
}
