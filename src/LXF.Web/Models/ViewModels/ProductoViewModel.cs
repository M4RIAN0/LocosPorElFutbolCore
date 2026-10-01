using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class ProductoViewModel
    {
        [Required(ErrorMessage = "El Nombre del Producto es Obligatorio.")]
        [StringLength(150, ErrorMessage = "El Nombre no Debe Superar los 150 Caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Descripción es Obligatoria.")]
        [StringLength(250, ErrorMessage = "La Descripción no Debe Superar los 250 Caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Precio es Obligatorio.")]
        [Range(1.00, 99999.99, ErrorMessage = "El Precio Debe Estar Entre $1 y $99.999.")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Debes Subir una Fotografía del Producto.")]
        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "Seleeciona un Genero.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Selecciona una Marca.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una Marca Válida.")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Selecciona una Categoría.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una Categoría Válida.")]
        public int CategoriaId { get; set; }

        public int Cantidad { get; set; }

        public List<ProductoVarianteViewModel> ProductosVariantes { get; set; } = [];
    }

    public class ProductoPutViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre del Producto es Obligatorio.")]
        [StringLength(150, ErrorMessage = "El Nombre no Debe Superar los 150 Caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Descripción es Obligatoria.")]
        [StringLength(250, ErrorMessage = "La Descripción no Debe Superar los 250 Caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Precio es Obligatorio.")]
        [Range(1.00, 99999.99, ErrorMessage = "El Precio Debe Estar Entre $1 y $99.999.")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Debes Subir una Fotografía del Producto.")]
        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "El Género es Obligatorio.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Selecciona una Marca.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una Marca Válida.")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Selecciona una Categoría.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una Categoría Válida.")]
        public int CategoriaId { get; set; }

        public int Cantidad { get; set; }

        public List<ProductoVariantePutViewModel> ProductosVariantes { get; set; } = [];
    }

    public class ProductoGetViewModel : ViewModelBase
    {
        public string Nombre { get; init; }

        public string Descripcion { get; init; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal Precio { get; init; }

        public int MarcaId { get; init; }

        public string Marca { get; init; }

        public int CategoriaId { get; init; }

        public string Categoria { get; init; }

        public string ImagenUrl { get; init; }
        public string Genero { get; init; }

        public int Cantidad { get; init; }

        public List<ProductoVarianteGetViewModel> ProductosVariantes { get; init; } = [];
    }

    public class ProductoResumenViewModel 
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
    }

}
