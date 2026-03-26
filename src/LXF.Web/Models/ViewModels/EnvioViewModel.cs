using Servicio.Base;

namespace LXF.Web.Models.ViewModels
{
    public class EnvioViewModel 
    {
        public string Persona { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Dni { get; set; }
        public decimal Monto { get; set; }
        public int ComprobanteId { get; set; }
    }

    public class EnvioGetViewModel : ViewModelBase
    {
        public string Persona { get; init; }
        public string Email { get; init; }
        public string Celular { get; init; }
        public string Direccion { get; init; }
        public string Dni { get; init; }
        public decimal Monto { get; init; }
        public int ComprobanteId { get; init; }
    }
}
