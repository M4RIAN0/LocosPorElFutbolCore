using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.MetaData
{
    public interface IUsuario
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string NombreUsuario { get; set; }

        [Required]
         string Password { get; set; }

         bool EstaBloqueado { get; set; }
    }
}
