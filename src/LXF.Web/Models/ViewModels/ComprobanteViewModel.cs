using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class ComprobanteViewModel
    {
        public required string Fecha { get; set; }
        public IEnumerable<DetalleComprobanteViewModel> DetalleComprobantes { get; set; }
        public required decimal Total { get; set; }
        public int ClienteId { get; set; }
        public int FacturaId { get; set; }
        public int EnvioId { get; set; }
    }

    public class ComprobanteGetViewModel : ViewModelBase
    {
        public string Fecha { get; init; }
        public IEnumerable<DetalleComprobanteGetViewModel> DetalleComprobantes { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; init; }
        public int ClienteId { get; init; }
        public FacturaGetViewModel Factura { get; set; }
        public EnvioGetViewModel Envio { get; set; }
    }
}
