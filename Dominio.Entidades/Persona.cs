using Dominio.Entidades.MetaData;
using DominioBase;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Personas")]
    [MetadataType(typeof(IPersona))]
    public partial class Persona: EntidadBase
    {

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Direccion { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }


        //propiedades de navegacion
    }
}
