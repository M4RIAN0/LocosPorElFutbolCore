using Servicio.Base;

namespace LXF.Web.Models.ViewModels
{
    public class ProvinciaGetViewModel : DtoBase
    {
        public string Nombre { get; set; }

        public IEnumerable<LocalidadGetViewModel> Localidades { get; set; }
    }
}
