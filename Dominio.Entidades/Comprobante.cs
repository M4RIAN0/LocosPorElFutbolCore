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

        public decimal Total { get; set; }



        //propiedades de navegacion

        public virtual ICollection<CuponDescuento> CuponDescuentos { get; set; }

       
        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }

        
        public virtual ICollection<Envio> Envios { get; set; }

        
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
