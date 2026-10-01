using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class DetalleComprobanteViewModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, 999)]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoBarra { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        public  string ProductoNombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Talle { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public  decimal Precio { get; set; }
        public  int ProductoId { get; set; }
        public int ComprobanteId { get; set; }
    }

    public class DetalleComprobanteGetViewModel : ViewModelBase
    {
        public int Cantidad { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; init; }
        public int CodigoBarra { get; init; }
        public string ProductoNombre { get; init; }
        public string Talle { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; init; }
        public int ProductoId { get; init; }
        public ProductoGetViewModel Producto { get; init; }
        public int ComprobanteId { get; init; }
    }
}
