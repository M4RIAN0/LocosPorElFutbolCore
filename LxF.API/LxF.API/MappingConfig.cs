using AutoMapper;
using Dominio.Entidades;
using IServicio.PersonaCliente.Dto;

namespace LxF.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonaClienteDto, Persona_Cliente>();
                config.CreateMap<Persona_Cliente, PersonaClienteDto>();
            });
            return mappingConfig;
        }
    }
}
