using Servicio.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IServicio.Dtos
{
    public class FacturaDto
    {
        public string Fecha { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

        public string TipoPago { get; set; }

        public int ClienteId { get; set; }

        public int ComprobanteId { get; set; }


    }

    public class FacturaGetDto : DtoBase
    {

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Fecha { get; init; }

        public string Estado { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; init; }

        public string TipoPago { get; init; }

        public int ClienteId { get; init; }

        public string Cliente { get; init; }

        public int ComprobanteId { get; init; }
    }
}
