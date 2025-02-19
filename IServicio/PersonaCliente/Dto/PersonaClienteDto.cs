using Servicio.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace IServicio.PersonaCliente.Dto
{
    public class PersonaClienteDto
    {
        public int Codigo { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Direccion { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }
    }

    public class PersonaClientePutDto : PersonaClienteDto
    {
        public int Id { get; set; }
    }

    public class PersonaClienteGetDto : DtoBase
    {
        public int Codigo { get; init; }

        public string Apellido { get; init; }

        public string Nombre { get; init; }

        public string Dni { get; init; }

        public string Direccion { get; init; }

        public string Sexo { get; init; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; init; }

        public string Celular { get; init; }

        public string Email { get; init; }

        public string PersonaStr => Apellido + " " + Nombre;
    }
}
