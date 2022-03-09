namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CuponDescuentos")]
    [MetadataType(typeof(ICuponDescuento))]
    public partial class CuponDescuento: EntidadBase
    {

        public string Descripcion { get; set; }

        public decimal Porcentaje { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaCaducidad { get; set; }



        //propiedad de navegacion
        public long? ComprobanteId { get; set; }

        public virtual Comprobante Comprobante { get; set; }
    }
}
