using Servicio.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class EnvioViewModel 
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Persona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(10, ErrorMessage = "El campo {0} no debe superar los {1} caractere")]
        public string Celular { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        public string Direccion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(8, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    }

    public class EnvioGetViewModel : ViewModelBase
    {
        public string Persona { get; init; }
        public string Email { get; init; }
        public string Celular { get; init; }
        public string Direccion { get; init; }
        public string Dni { get; init; }
        public decimal Monto { get; init; }
        public string Estado { get; init; }
    }
}
