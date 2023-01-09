namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comprobantes")]
    [MetadataType(typeof(IComprobante))]
    public partial class Comprobante: EntidadBase
    {
        
        public DateTime Fecha { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }



        //propiedades de navegacion

        public virtual IEnumerable<CuponDescuento> CuponDescuentos { get; set; }

       
        public virtual IEnumerable<DetalleComprobante> DetalleComprobantes { get; set; }

        
        public virtual IEnumerable<Envio> Envios { get; set; }

        
        public virtual IEnumerable<Factura> Facturas { get; set; }
    }
}
