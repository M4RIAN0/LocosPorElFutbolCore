using Dominio.Repositorio.PersonaCliente;
using IServicio.PersonaCliente;
using IServicio.PersonaCliente.Dto;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.PersonaCliente
{
    public class PersonaClienteServicio : ServicioBase, IPersonaClienteServicio
    {

        private readonly IPersonaClienteRepositorio _personaClienteRepositorio;

        public PersonaClienteServicio(IPersonaClienteRepositorio personaClienteRepositorio)
        {
            _personaClienteRepositorio = personaClienteRepositorio;
        }

        public void Add(PersonaClienteDto Dto)
        {
            var Persona = new Dominio.Entidades.Personas_Cliente
            {
                Codigo = Dto.Codigo,
                Apellido = Dto.Apellido,
                Nombre = Dto.Nombre,
                Dni = Dto.Dni,
                Direccion = Dto.Direccion,
                Sexo = Dto.Sexo,
                FechaNacimiento = Dto.FechaNacimiento,
                Celular = Dto.Celular,
                Email = Dto.Email,
                RowVersion = Dto.RowVersion

            };

            _personaClienteRepositorio.Agregar(Persona);
            _personaClienteRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _personaClienteRepositorio.Eliminar(Id);
            _personaClienteRepositorio.Save();
        }

        public IEnumerable<PersonaClienteDto> GetAll()
        {
            return _personaClienteRepositorio.ObtenerTodo()
                .Select(x => new PersonaClienteDto
                {
                    Codigo = x.Codigo,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    Dni = x.Dni,
                    Direccion = x.Direccion,
                    Sexo = x.Sexo,
                    FechaNacimiento = x.FechaNacimiento,
                    Celular = x.Celular,
                    Email = x.Email,
                    RowVersion = x.RowVersion

                }).ToList();
        }


   
        public IEnumerable<PersonaClienteDto> GetByFilter(string cadenaBuscar)
        {
            var codigo = -1;
            int.TryParse(cadenaBuscar, out codigo);

            return _personaClienteRepositorio.ObtenerPorFlitro(x => x.Apellido.Contains(cadenaBuscar) || x.Dni == codigo.ToString())
            .Select(x => new PersonaClienteDto
            {
                Codigo = x.Codigo,
                Apellido = x.Apellido,
                Nombre = x.Nombre,
                Dni = x.Dni,
                Direccion = x.Direccion,
                Sexo = x.Sexo,
                FechaNacimiento = x.FechaNacimiento,
                Celular = x.Celular,
                Email = x.Email,
                RowVersion = x.RowVersion

            }).ToList();
        }

        public PersonaClienteDto GetById(long? Id)
        {
            var personaCliente = _personaClienteRepositorio.ObtenerPorId(Id);

            if (personaCliente == null) throw new ArgumentNullException("No se encontro la persona");

            return new PersonaClienteDto
            {
                Id = personaCliente.Id,
                Codigo = personaCliente.Codigo,
                Apellido = personaCliente.Apellido,
                Nombre = personaCliente.Nombre,
                Dni = personaCliente.Dni,
                Direccion = personaCliente.Direccion,
                Sexo = personaCliente.Sexo,
                FechaNacimiento = personaCliente.FechaNacimiento,
                Celular = personaCliente.Celular,
                Email = personaCliente.Email,

            };
        }

        public void Update(PersonaClienteDto Dto)
        {
            var personaCliente = _personaClienteRepositorio.ObtenerPorId(Dto.Id);


            personaCliente.Apellido = Dto.Apellido;
            personaCliente.Nombre = Dto.Nombre;
            personaCliente.Dni = Dto.Dni;
            personaCliente.Direccion = Dto.Direccion;
            personaCliente.Sexo = Dto.Sexo;
            personaCliente.FechaNacimiento = Dto.FechaNacimiento;
            personaCliente.Celular = Dto.Celular;
            personaCliente.Email = Dto.Email;

        }
    }
}
