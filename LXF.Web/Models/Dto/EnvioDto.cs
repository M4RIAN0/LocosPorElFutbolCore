using Servicio.Base;

namespace IServicio.Dtos
{
    public class EnvioDto : DtoBase
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public int LocalidadId { get; set; }
        public int Comprobante_Id { get; set; }
        public string ComprobanteStr { get; set; }
        public string LocalidadeStr { get; set; }
    }
}
