using Dominio.Repositorio.Persona;
using IServicio.Persona;
using IServicio.Persona.Dto;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Persona
{
    public class PersonaServicio : ServicioBase, IPersonaServicio
    {
        private readonly IPersonaRepositorio _personaRepositorio;

        public PersonaServicio(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
        }

        public void Add(PersonaDto Dto)
        {
            var Persona = new Dominio.Entidades.Persona
            {
                Apellido = Dto.Apellido,
                Nombre = Dto.Nombre,
                FechaNacimiento = Dto.FechaNacimiento,
                Celular = Dto.Celular,
                RowVersion = Dto.RowVersion

            };

            _personaRepositorio.Agregar(Persona);
            _personaRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _personaRepositorio.Eliminar(Id);

            _personaRepositorio.Save();
        }

        public IEnumerable<PersonaDto> GetAll()
        {
            return _personaRepositorio.ObtenerTodo()
                .Select(x => new PersonaDto
                {
                    Id = x.Id,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    Celular = x.Celular,
                    FechaNacimiento = x.FechaNacimiento,
                    RowVersion = x.RowVersion
                }).ToList();
        }

        public IEnumerable<PersonaDto> GetByFilter(string cadenaBuscar)
        {
            return _personaRepositorio.ObtenerPorFlitro(x => x.Apellido.Contains(cadenaBuscar))
            .Select(x => new PersonaDto
            {
                Id = x.Id,
                Apellido = x.Apellido,
                Nombre = x.Nombre,
                Celular = x.Celular,
                FechaNacimiento = x.FechaNacimiento,
            }).ToList();
        }

        public PersonaDto GetById(long? Id)
        {
            var Persona = _personaRepositorio.ObtenerPorId(Id);

            if (Persona == null) throw new ArgumentNullException("No se encontro la persona");

            return new PersonaDto
            {
                Id = Persona.Id,
                Apellido = Persona.Apellido,
                Nombre = Persona.Nombre,
                Celular = Persona.Celular,
                FechaNacimiento = Persona.FechaNacimiento,
                RowVersion = Persona.RowVersion

            };
        }

        public void Update(PersonaDto Dto)
        {
            var Persona = _personaRepositorio.ObtenerPorId(Dto.Id);

            Persona.Apellido = Dto.Apellido;
            Persona.Nombre = Dto.Nombre;
            Persona.Celular = Dto.Celular;
            Persona.FechaNacimiento = Dto.FechaNacimiento;

            _personaRepositorio.Modificar(Persona);
            _personaRepositorio.Save();
        }
    }
}
