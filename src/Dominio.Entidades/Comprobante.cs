namespace Dominio.Entidades
{
    using DominioBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comprobantes")]
    public partial class Comprobante : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateOnly Fecha { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }


        //propiedades de navegacion
        public virtual IEnumerable<DetalleComprobante> DetalleComprobantes { get; set; }
        public virtual IEnumerable<Envio> Envios { get; set; }
        public virtual IEnumerable<Factura> Facturas { get; set; }
    }
}
