using Servicio.Base;
using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class ProvinciaGetViewModel : DtoBase
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        public IEnumerable<LocalidadGetViewModel> Localidades { get; set; }
    }
}
