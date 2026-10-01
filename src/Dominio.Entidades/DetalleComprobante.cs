namespace Dominio.Entidades
{
    using DominioBase;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DetalleComprobantes")]
    public partial class DetalleComprobante : MasterEntityModel
    {
        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public int CodigoBarra { get; set; }

        [Required]
        public string ProductoNombre { get; set; }
        
        [Required]
        public string Talle { get; set; }

        [Required]
        public decimal Precio { get; set; }



        //propiedades de navegacion
        public int ProductoId { get; set; }
        public int ComprobanteId { get; set; }
        public virtual Comprobante Comprobante { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
