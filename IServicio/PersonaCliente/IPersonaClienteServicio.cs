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

        IEnumerable<PersonaClienteDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        Task <IEnumerable<PersonaClienteDto>> GetAll();

        PersonaClienteDto GetById(long? Id);
    }
}
