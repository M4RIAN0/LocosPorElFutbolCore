using Servicio.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace IServicio.Persona.Dto
{
    public class PersonaDto : DtoBase
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Direccion { get; set; }

        public string Sexo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }
    }
}
