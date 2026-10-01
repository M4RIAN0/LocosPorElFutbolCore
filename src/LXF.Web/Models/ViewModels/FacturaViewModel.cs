using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class FacturaViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(8, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Dni { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        public string Direccion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(10, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public string TipoPago { get; set; }
    }

    public class FacturaGetViewModel : ViewModelBase
    {
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Fecha { get; init; }
        public string Estado { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; init; }
        public string TipoPago { get; init; }

    }
}
