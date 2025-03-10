namespace Dominio.Entidades
{
    using DominioBase;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DetalleComprobantes")]
    public partial class DetalleComprobante : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, 999)]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoBarra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }



        //propiedades de navegacion
        public int ProductoId { get; set; }

        public int ComprobanteId { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
