using Servicio.Base;

namespace IServicio.Dtos
{
    public class EnvioDto : DtoBase
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public int LocalidadId { get; set; }
        public int ComprobanteId { get; set; }
        public string Comprobante { get; set; }
        public string Localidad { get; set; }
    }
}
