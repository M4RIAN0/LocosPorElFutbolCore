using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IPersona
    {
        [Required]
         string Apellido { get; set; }

        [Required]
         string Nombre { get; set; }

        [Required]
        [StringLength(8)]
         string Dni { get; set; }

        [Required]
         string Direccion { get; set; }

        [Required]
         string Sexo { get; set; }

         DateTime FechaNacimiento { get; set; }

        [Required]
         string Celular { get; set; }

        [Required]
         string Email { get; set; }
    }
}
