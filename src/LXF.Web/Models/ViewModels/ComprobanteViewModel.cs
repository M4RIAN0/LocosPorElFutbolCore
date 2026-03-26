using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class ComprobanteViewModel
    {
        public required string Fecha { get; set; }
        public IEnumerable<DetalleComprobanteViewModel> DetalleComprobantes { get; set; }
        public required decimal Total { get; set; }
        public int ClienteId { get; set; }

        //Seccion Facturacion y Envio
        public FacturaViewModel Factura { get; set; }
        public EnvioViewModel Envio { get; set; }
    }

    public class ComprobanteGetViewModel : ViewModelBase
    {
        public string Fecha { get; init; }
        public IEnumerable<DetalleComprobanteGetViewModel> DetalleComprobantes { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; init; }
        public int ClienteId { get; init; }

        //Seccion Facturacion y Envio
        public FacturaViewModel? Factura { get; init; }
        public EnvioViewModel? Envio { get; init; }
    }
}
