using Servicio.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IServicio.Dtos
{
    public class ComprobanteDto
    {
        public string Fecha { get; set; }
        public IEnumerable<DetalleComprobanteDto> DetalleComprobantes { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public FacturaDto Factura { get; init; }
        public EnvioDto Envio { get; init; }
    }

    public class ComprobanteGetDto : DtoBase
    {
        public string Fecha { get; init; }
        public IEnumerable<DetalleComprobanteGetDto> DetalleComprobantes { get; init; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; init; }
        public int ClienteId { get; init; }
        public FacturaGetDto? Factura { get; init; }
        public EnvioGetDto? Envio { get; init; }
    }
}
