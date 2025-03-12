using Servicio.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace IServicio.Dtos
{
    public class DetalleComprobanteDto
    {
        public int Cantidad { get; set; }

        public decimal SubTotal { get; set; }

        public int CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int ProductoId { get; set; }

        public int ComprobanteId { get; set; }
    }

    public class DetalleComprobanteGetDto : DtoBase
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
