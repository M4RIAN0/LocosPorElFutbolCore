using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class CategoriaViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "La {0} es Obligatoria.")]
        [StringLength(200, ErrorMessage = "El {0} no Debe Superar los {1} Caracteres.")]
        public required string Descripcion { get; set; }
    }

    public class CategoriaPutViewModel : CategoriaViewModel
    {
        public int Id { get; set; }
    }

    public class CategoriaGetViewModel : ViewModelBase
    {
        public string Descripcion { get; init; }
    }
}
