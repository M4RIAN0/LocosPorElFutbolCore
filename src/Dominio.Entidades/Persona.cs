using DominioBase;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Personas")]
    public partial class Persona : MasterEntityModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public DateOnly FechaNacimiento { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
