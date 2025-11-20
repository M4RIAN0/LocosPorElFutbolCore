using Servicio.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IServicio.Dtos
{
    public class ComprobanteDto
    {
        public string Fecha { get; set; }

        public IEnumerable<DetalleComprobanteDto> DetalleComprobantes { get; set; }

        public decimal Total { get; set; }
    }

    public class ComprobanteGetDto : DtoBase
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Fecha { get; init; }

        public IEnumerable<DetalleComprobanteGetDto> DetalleComprobantes { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; init; }
    }
}
