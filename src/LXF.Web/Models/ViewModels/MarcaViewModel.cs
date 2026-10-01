using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class MarcaViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "La {0} es Obligatoria.")]
        [StringLength(240, ErrorMessage = "El {0} no Debe Superar los {1} Caracteres.")]
        public required string Descripcion { get; set; }
    }

    public class MarcaPutViewModel : MarcaViewModel
    {
        public int Id { get; set; }
    }

    public class MarcaGetViewModel : ViewModelBase
    {
        public string Descripcion { get; init; }
    }
}
