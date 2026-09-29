using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class LocalidadGetViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CP { get; set; }
        public int ProvinciaId { get; set; }
    }
}