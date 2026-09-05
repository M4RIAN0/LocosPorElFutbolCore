using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class ProductoViewModel
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no debe superar los 150 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El código de barra es obligatorio.")]
        [Range(100000, 999999, ErrorMessage = "El código debe ser numérico y tener exactamente 6 dígitos.")]
        public int CodigoBarra { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(250, ErrorMessage = "La descripción no debe superar los 250 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(1.00, 99999.99, ErrorMessage = "El precio debe estar entre $1 y $99.999.")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock inicial es obligatorio.")]
        [Range(0, 100, ErrorMessage = "El stock no puede superar las 100 unidades.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Debes subir una fotografía del producto.")]
        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "Selecciona una marca.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una marca válida.")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Selecciona un talle válido.")]
        public string Talle { get; set; }

        [Required(ErrorMessage = "Selecciona una categoría.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una categoría válida.")]
        public int CategoriaId { get; set; }

        [Range(1, 100)]
        public int Cantidad { get; init; } = 1;
    }

    public class ProductoPutViewModel : ProductoViewModel
    {
        public int Id { get; set; }
    }

    public class ProductoGetViewModel : ViewModelBase
    {
        public string Nombre { get; init; }

        public int CodigoBarra { get; init; }

        public string Descripcion { get; init; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal Precio { get; init; }

        public int Stock { get; init; }

        public int MarcaId { get; init; }

        public string Marca { get; init; }

        public string Talle { get; init; }

        public int CategoriaId { get; init; }

        public string Categoria { get; init; }

        public string ImagenUrl { get; init; }

        [Range(1, 100)]
        public  int Cantidad { get; init; } = 1;
    }
       
}
