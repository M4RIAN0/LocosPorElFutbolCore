using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class FacturaViewModel
    {
        public required string Fecha { get; set; }

        public required string Estado { get; set; }

        public required decimal Total { get; set; }

        public required string TipoPago { get; set; }

        public required int ClienteId { get; set; }

        public int? ComprobanteId { get; set; }

        public int? TarjetaId { get; set; }

        public TarjetaViewModel Tarjeta { get; set; }

        public ComprobanteViewModel Comprobante { get; set; }


    }

    public class FacturaGetViewModel : ViewModelBase
    {

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Fecha { get; init; }

        public string Estado { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; init; }

        public string Cliente { get; init; }

        public string TipoPago { get; set; }

        public string Tarjeta { get; set; }

    }
}
