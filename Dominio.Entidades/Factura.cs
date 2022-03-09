namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Facturas")]
    [MetadataType(typeof(IFactura))]
    public partial class Factura: EntidadBase
    {
        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

        public int Codigo { get; set; }



        //propiedades de navegacion
        public long ClienteId { get; set; }

        public long Comprobante_Id { get; set; }

        public long Movimiento_Id { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual Personas_Cliente Personas_Cliente { get; set; }

        public virtual Movimiento Movimiento { get; set; }
    }
}
