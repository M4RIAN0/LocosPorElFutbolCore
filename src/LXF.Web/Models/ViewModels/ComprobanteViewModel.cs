using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class ComprobanteViewModel
    {
        public required string Fecha { get; set; }

        public IEnumerable<DetalleComprobanteViewModel> DetalleComprobantes { get; set; }

        public required decimal Total { get; set; }
    }

    public class ComprobanteGetViewModel : ViewModelBase
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Fecha { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }
}
