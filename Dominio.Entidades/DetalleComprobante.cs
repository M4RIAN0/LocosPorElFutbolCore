namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DetalleComprobantes")]
    [MetadataType(typeof(IDetalleComprobante))]
    public partial class DetalleComprobante: EntidadBase
    {
        public int Cantidad { get; set; }

        public decimal SubTotal { get; set; }

        public int Codigo { get; set; }

        public int CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }



        //propiedades de navegacion
        public long ProductoId { get; set; }

        public long ComprobanteId { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
