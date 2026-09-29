using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class ProductoVarianteViewModel
    {
        [Required(ErrorMessage = "El Talle es obligatorio.")]
        [StringLength(2)]
        public string Talle { get; set; }

        [Required(ErrorMessage = "El Stock es obligatorio.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El Codigo de Barra es obligatorio.")]
        [Range(1, 99999, ErrorMessage = "El rango debe estar entre 1 y 99999.")]
        public int CodigoBarra { get; set; }
        public int ProductoId { get; set; }
    }
    public class ProductoVariantePutViewModel: ProductoVarianteViewModel
    {
        public int Id { get; set; }
    }

        public class ProductoVarianteGetViewModel: ViewModelBase
    {
        public string Talle { get; init; }
        public int Stock { get; init; }
        public int CodigoBarra { get; init; }
        public int ProductoId { get; init; }
        public ProductoResumenViewModel Producto { get; init; }
    }
}