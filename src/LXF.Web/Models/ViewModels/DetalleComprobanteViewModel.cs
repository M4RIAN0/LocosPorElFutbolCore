using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class DetalleComprobanteViewModel
    {
        public required int Cantidad { get; set; }

        public required decimal SubTotal { get; set; }

        public required int CodigoBarra { get; set; }

        public required string Descripcion { get; set; }

        public required decimal Precio { get; set; }

        public required int ProductoId { get; set; }

        public required int ComprobanteId { get; set; }
    }

    public class DetalleComprobanteGetViewModel : ViewModelBase
    {
        public int Cantidad { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; init; }

        public int CodigoBarra { get; init; }

        public string Descripcion { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; init; }

        public string Producto { get; init; }

        public int ComprobanteId { get; init; }
    }
}
