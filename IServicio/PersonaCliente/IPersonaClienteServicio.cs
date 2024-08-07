using IServicio.PersonaCliente.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IServicio.PersonaCliente
{
    public interface IPersonaClienteServicio
    {
        void Add(PersonaClienteDto Dto);
        void Update(PersonaClienteDto Dto);
        void Delete(long Id);

        Task <IEnumerable<PersonaClienteDto>> GetByFilter(string cadenaBuscar);

        Task <IEnumerable<PersonaClienteDto>> GetAll();

        Task <PersonaClienteDto> GetById(long? Id);
    }
}
