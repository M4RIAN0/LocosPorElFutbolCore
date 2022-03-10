
using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.MetaData
{
    public interface IPersona
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(8, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string Dni { get; set; }

        [Required]
         string Direccion { get; set; }

        [Required]
         string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        string Genero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(10, ErrorMessage = "El campo {0} no debe superar los {1} caractere")]
        string Telefono { get; set; }
    }
}
